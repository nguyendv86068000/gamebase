using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GunController m_gunController;
    [SerializeField] private Transform m_aimTarget;
    [SerializeField] private LineRenderer m_lineRenderer;
    [SerializeField] private Bullet m_bulletPrefab;

    private Vector3 m_headGun;
    private Ray m_rayGun;
    private List<EnemyBase> enemiesHitted;

    private void OnEnable()
    {
        EventManager.MouseButtonDown += HandleFingerDown;
        EventManager.MouseButtonUp += HandleFingerUp;
        EventManager.MouseButtonDownUpdate += HandleFingerUpdate;

    }
    private void OnDisable()
    {
        EventManager.MouseButtonDown -= HandleFingerDown;
        EventManager.MouseButtonUp -= HandleFingerUp;
        EventManager.MouseButtonDownUpdate -= HandleFingerUpdate;
    }
    private void Start()
    {
        m_aimTarget.gameObject.SetActive(false);
        ClearAllPointLineRenderer();
        enemiesHitted = new List<EnemyBase>();
    }
    private void InstantiateBullet()
    {
        Bullet bullet = Instantiate(m_bulletPrefab);
        // đoạn này cho ra ngoài một chút để tránh làm ảnh hưởng tới player do 2 collison chồng nhau
        bullet.transform.position = m_rayGun.GetPoint(0.5f);
        bullet.Init(m_rayGun.direction.normalized);
    }

    private void ClearAllPointLineRenderer()
    {
        m_lineRenderer.positionCount = 0;
    }
    private void DrawLineRenderer(Vector3 begin, Ray ray, float distance)
    {
        ClearAllPointLineRenderer();
        Vector3 end = ray.GetPoint(distance);
        end.z = 0;
        m_lineRenderer.positionCount = 2;
        m_lineRenderer.SetPosition(0, begin);
        m_lineRenderer.SetPosition(1, end);
    }

    private void SetAimTargetPosition(Vector3 pos)
    {
        m_aimTarget.position = new Vector3(pos.x, pos.y, 0);
    }
    private void HandleFingerDown()
    {
        m_aimTarget.gameObject.SetActive(true);
    }
    private void HandleFingerUp()
    {
        m_aimTarget.gameObject.SetActive(false);
        ClearAllPointLineRenderer();
        InstantiateBullet();
    }
    void HandleFingerUpdate(Vector3 mousePos)
    {
        m_headGun = transform.position;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWorldPos.z = 0;
        m_rayGun = new Ray(m_headGun, mouseWorldPos - m_headGun);


        SetAimTargetPosition(mouseWorldPos);
        DrawLineRenderer(m_headGun, m_rayGun, 200f);

        FindAllEnemyOnRay(m_headGun, m_rayGun.direction);
    }

    private void FindAllEnemyOnRay(Vector2 headGun, Vector2 direction)
    {
        var raycastAll = Physics2D.RaycastAll(headGun, direction, 1000f).ToList();
        var enemies = raycastAll.Where(p => p.collider.GetComponent<EnemyBase>() != null)
            .Select(p => p.collider.GetComponent<EnemyBase>());
        foreach (var enemy in enemies)
        {
            enemy.OnHitted();
        }
        foreach (var enemy in enemiesHitted)
        {
            if (!enemies.Contains(enemy))
            {
                enemy.OnIdle();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GunController m_gunController;
    [SerializeField] private Transform m_aimTarget;
    [SerializeField] private LineRenderer m_lineRenderer;

    private Vector3 m_headGun;
    private Ray m_rayGun;

    void OnEnable()
    {
        EventManager.MouseButtonDown += HandleFingerDown;
        EventManager.MouseButtonUp += HandleFingerUp;
        EventManager.MouseButtonDownUpdate += HandleFingerUpdate;

    }
    void OnDisable()
    {
        EventManager.MouseButtonDown -= HandleFingerDown;
        EventManager.MouseButtonUp -= HandleFingerUp;
        EventManager.MouseButtonDownUpdate -= HandleFingerUpdate;
    }
    private void Start()
    {
        m_aimTarget.gameObject.SetActive(false);
        ClearAllPointLineRenderer();
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

    public void SetAimTargetPosition(Vector3 pos)
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
    }
    void HandleFingerUpdate(Vector3 mousePos)
    {
        m_headGun = transform.position;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWorldPos.z = 0;
        m_rayGun = new Ray(m_headGun, mouseWorldPos - m_headGun);


        SetAimTargetPosition(mouseWorldPos);
        DrawLineRenderer(m_headGun, m_rayGun, 200f);
    }
}

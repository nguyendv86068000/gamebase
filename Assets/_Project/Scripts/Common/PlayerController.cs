using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GunController m_gunController;
    [SerializeField] private Transform m_aimTarget;
    [SerializeField] private LineRenderer m_lineRenderer;

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
    private void DrawLineRenderer(Vector3 begin, Vector3 end, float distance)
    {
        ClearAllPointLineRenderer();
        Ray ray = new Ray(begin, end - begin);
        Vector3 newEnd = ray.GetPoint(distance);
        newEnd.z = 0;
        m_lineRenderer.positionCount = 2;
        m_lineRenderer.SetPosition(0, begin);
        m_lineRenderer.SetPosition(1, newEnd);
    }

    public void SetAimTargetPosition(Vector3 pos)
    {
        m_aimTarget.localPosition = new Vector3(pos.x, pos.y, m_aimTarget.localPosition.z);
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
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        SetAimTargetPosition(mouseWorldPos);
        DrawLineRenderer(transform.position, mouseWorldPos, 200f);
    }
}

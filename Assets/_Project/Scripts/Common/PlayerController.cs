using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GunController gunController;
    private Transform aimTarget => gunController.AimTarget;

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
        aimTarget.gameObject.SetActive(false);
    }
    public void SetAimTargetPosition(Vector3 pos)
    {
        aimTarget.position = new Vector3(pos.x, pos.y, 10);
    }
    private void HandleFingerDown()
    {
        aimTarget.gameObject.SetActive(true);
    }
    private void HandleFingerUp()
    {
        aimTarget.gameObject.SetActive(false);
    }
    void HandleFingerUpdate(Vector3 mousePos)
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        SetAimTargetPosition(mouseWorldPos);
    }
}

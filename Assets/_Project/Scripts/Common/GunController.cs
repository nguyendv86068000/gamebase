using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform aimTarget;
    public Transform AimTarget => aimTarget;
    [SerializeField] private LineRenderer lineRenderer;

}

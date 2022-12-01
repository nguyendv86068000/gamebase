using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private float bulletSpeed = 1f;
    [SerializeField] private int bounceTime = 10;
    [SerializeField] private Vector3 direction;
    [SerializeField] private LayerMask layerMask;

    public void Init(Vector3 dir)
    {
        direction = dir;
    }

    public void Update()
    {
        Vector3 nextPos = direction * Time.deltaTime * bulletSpeed;
        Debug.DrawLine(transform.position, nextPos, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1000, layerMask);
        if(hit.collider != null)
        {
            if(Vector3.Distance(transform.position, hit.point) < 0.1f)
            {
                OnBounce();
                direction = Vector3.Reflect(direction, hit.normal);
                transform.position = hit.point;
            }
        }
        //if(hit.collider != null)
        //{
        //        Debug.Log("adsadasd");
        //}
        MoveAllowDirectionUpdate();
    }

    private void MoveAllowDirectionUpdate()
    {
        transform.position += direction * Time.deltaTime * bulletSpeed;
    }

    private void OnBounce()
    {

    }
    private void OnBecameInvisible()
    {
        HideBullet();
    }

    private void HideBullet()
    {
        trailRenderer.Clear();
        //Destroy(gameObject);
    }

}

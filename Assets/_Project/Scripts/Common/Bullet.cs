using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Bullet : MonoBehaviour, IPoolerSpawn
{
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private float bulletSpeed = 1f;
    [SerializeField] private int bounceTime => Config.BounceTime;
    [SerializeField] private int currentBounceTime;
    [SerializeField] private Vector3 direction;
    [SerializeField] private LayerMask layerMask;
    private Action m_hideBullet;
    
    public void Initialize(Vector3 position, Vector3 direction, Action hideBullet)
    {
        ResetData();
        transform.position = position;
        this.direction = direction;
        m_hideBullet = hideBullet;
    }

    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 2, layerMask);
        if(hit.collider != null)
        {
            if(Vector3.Distance(transform.position, hit.point) < 0.1f)
            {
                Debug.Log("đổi hường");
                OnBounce();
                direction = Vector3.Reflect(direction, hit.normal);
                transform.position = hit.point;
            }
        }
        MoveAllowDirectionUpdate();
    }

    private void MoveAllowDirectionUpdate()
    {
        transform.position += direction * Time.deltaTime * bulletSpeed;
    }

    private void OnBounce()
    {
        currentBounceTime++;
        if (currentBounceTime > bounceTime)
        {
            HideBullet();
        }
    }
    private void OnBecameInvisible()
    {
        //HideBullet();
    }

    private void HideBullet()
    {
        trailRenderer.Clear();
        m_hideBullet?.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IAffectedByBullet dieElement = collision.GetComponent<IAffectedByBullet>();
        if (dieElement != null)
        {
            dieElement.AffectedByBullet();
        }
    }

    public void ResetData()
    {
        currentBounceTime = 0;
        direction = Vector3.zero;
        m_hideBullet = null;
    }
}

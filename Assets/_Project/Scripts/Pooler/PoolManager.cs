using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private PoolGameObject poolBullet;
    private void Awake()
    {
        EventManager.PoolBullet += HandlePoolBullet;
    }

    private void OnDestroy()
    {
        EventManager.PoolBullet -= HandlePoolBullet;
    }

    private void HandlePoolBullet(Vector3 position, Vector3 direction)
    {
        Bullet bullet = poolBullet.Pool.Get().GetComponent<Bullet>();
        bullet.Initialize(position, direction, () => { poolBullet.Pool.Release(bullet.gameObject); });
    }

}

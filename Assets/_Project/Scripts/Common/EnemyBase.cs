using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBase : MonoBehaviour
{
    Sequence sequence;
    public void OnHitted()
    {
        //sequence = AnimSimple.Zoomer(gameObject, 1.2f, 1);
    }
    public void OnIdle()
    {
        //sequence.Kill();
    }
    public void OnDie()
    {
        Destroy(gameObject);
    }
}

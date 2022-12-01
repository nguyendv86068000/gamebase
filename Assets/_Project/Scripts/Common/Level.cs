using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    public enum LevelType
    {
        KillAllEnemies,
        Boss
    }
    [SerializeField] private LevelType levelType;
    [SerializeField] private int countBullet;
    [Tooltip("Not edit. Reset by set count to 0.")]
    [SerializeField] private List<EnemyBase> enemies;


    private void OnValidate()
    {
        if (enemies.Count == 0)
        {
            enemies = GetComponentsInChildren<EnemyBase>().ToList();
        }
    }
}

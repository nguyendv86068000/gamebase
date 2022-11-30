using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public enum LevelType
    {
        KillAllEnemies,
        Boss
    }
    [SerializeField] private LevelType levelType;
}

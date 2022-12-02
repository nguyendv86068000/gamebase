using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Config", menuName = "ScriptObject/Config")]
public class Config : ScriptableObject
{
    private static Config instance;
    private static Config Instance => instance ? instance : (instance = Resources.Load<Config>(Constants.CONFIG));


    [SerializeField] private bool isDebug;
    public static bool IsDebug => Instance.isDebug;


    // pramas game
    [Header("Paramas game")]
    [SerializeField] private int bounceTime;
    public static int BounceTime => Instance.bounceTime;
}

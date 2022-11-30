using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GAMESTATE
    {
        BEGIN,
        PLAYING,
        WIN,
        LOSE,
        INTRO
    }
    [SerializeField] private GAMESTATE gameState;

    public GAMESTATE GameState => gameState;
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    #region DataEvent
    public static Action OnDebugChanged;
    public static Action SaveCurrencyTotal;
    public static Action CurrencyTotalChanged;
    public static Action CurrentLevelChanged;
    public static Action OnSoundChanged;
    #endregion


    #region Event in Level
    public static Action OnWinLevel;
    public static Action OnLoseLevel;
    #endregion
}

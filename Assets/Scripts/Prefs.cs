using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{
    public static void SetBool(bool isTrue, string key)
    {
        if(isTrue)
        {
            PlayerPrefs.SetInt(key, 1);
        }
        else{
            PlayerPrefs.SetFloat(key, 0);
        }
    }
    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }

    public static bool IsLevelUnlocked(int level)
    {
        return GetBool(PrefConsts.LEVEL_UNLOCKED + level);
    }
    public static void SetLevelUnlocked(int level, bool unlocked)
    {
        SetBool(unlocked, PrefConsts.LEVEL_UNLOCKED + level);
    }
    public static bool IsLevelPassed(int level)
    {
        return GetBool(PrefConsts.LEVEL_PASSED + level);
    }
    
    public static void SetLevelPassed(int level, bool unlocked)
    {
        SetBool(unlocked, PrefConsts.LEVEL_PASSED + level);
    }
    public static bool IsGameEntered()
    {
        return GetBool(PrefConsts.IS_GAME_ENTERED);
    }
    public static void SetGameEntered(bool isEntered)
    {
        SetBool(isEntered, PrefConsts.IS_GAME_ENTERED);
    }
}

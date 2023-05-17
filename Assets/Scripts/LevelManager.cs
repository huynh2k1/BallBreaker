using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject[] levelPrefab;

    int currentLevel;
    public int CurLevel{get => currentLevel; set => currentLevel = value;}

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int m_level;
    GameObject m_levelObject;

    public int Level{get => m_level;}
    public GameObject LevelObject{get => m_levelObject;}
    private void Start() {
        GameObject[] levelPrefabs = LevelManager.Ins.levelPrefab;
        if(levelPrefabs != null && levelPrefabs.Length > 0 && levelPrefabs.Length > LevelManager.Ins.CurLevel)
        {
            GameObject levelPrefab = levelPrefabs[LevelManager.Ins.CurLevel];
            if(levelPrefab != null)
            {
                m_level = LevelManager.Ins.CurLevel;
                m_levelObject = Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
            }
        }
    }
}

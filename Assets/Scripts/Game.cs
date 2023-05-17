using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private BoxSpawn spawner;
    private void Start()
    {
        spawner = FindObjectOfType<BoxSpawn>();
    }
    public void EndTurn()
    {
        if(!spawner.DoesAnyBoxExist())
        {
            // Debug.Log("Game end! Win");
            // return;
            GUIManager.Instance.Win();
        }
        spawner.MoveBoxDown();
        if(spawner.DoesAnyBoxReachBottom())
        {
            GUIManager.Instance.Lose();
        }
        if(spawner.DoesWarning())
        {
            Debug.Log("Warning!");
            return;
        }
    }

}

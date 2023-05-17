using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Box : MonoBehaviour
{
    public int hp;
    public TMP_Text textMesh;
    void Start()
    {
        textMesh.text = hp.ToString();
    }

    public void ReduceHp(int amount)
    {
        hp -= amount;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        else{
            textMesh.text = hp.ToString();
        }
    }

}

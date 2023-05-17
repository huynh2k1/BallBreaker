using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreateMap : MonoBehaviour
{
    public GameObject cell;
    // Start is called before the first frame update
    public List<GameObject> levelPrefab;
    public int width;
    public int height;
    void Start()
    {
        for(int i = 0; i < width; i++) {
            for(int j = 0; j < height; j++) {
                Vector2 pos = new Vector2(i,j);
                Instantiate(cell, pos, Quaternion.identity);
            }
        }
    }

}

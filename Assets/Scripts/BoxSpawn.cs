using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{

    public Box boxPrefab;
    public int startY;
    public int endY;
    public int maxX;
    private void Start() {
        // for(int i = 0; i < maxX; i++) {
        //     for(int j = startY; j < endY; j++) {
        //         Vector2 pos = new Vector2(i, j);
        //         Box newBox = Instantiate(boxPrefab, pos, Quaternion.identity);
        //     }
        // }
    }
    public bool DoesAnyBoxExist()
    {
        Box[] boxes = FindObjectsOfType<Box>();
        return boxes.Length > 0;
    }
    public void MoveBoxDown()
    {
        Box[] boxes = FindObjectsOfType<Box>();

        foreach(Box box in boxes) {
            box.transform.position += Vector3.down;
        }
    }
    public bool DoesAnyBoxReachBottom()
    {
        Box[] boxes = FindObjectsOfType<Box>();
        foreach(Box box in boxes)
        {
            if(box.transform.position.y <= 0.05f)
            {
                return true;
            }
        }
        return false;
    }
    public bool DoesWarning()
    {
        Box[] boxes = FindObjectsOfType<Box>();
        foreach(Box box in boxes)
        {
            if(box.transform.position.y <= 2)
            {
                return true;
            }
        }
        return false;
    }
}

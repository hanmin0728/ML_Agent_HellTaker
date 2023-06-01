using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapArray
{
    public int[,] mapArray;
}

public class MapManager : MonoBehaviour
{
    public int xLength = 0;
    public int yLength = 0;

    public MapArray[] mapArrays;

    public GameObject a;
    void Start()
    {
        //mapArrays = new int[xLength, yLength];

        //for (int i = 0; i < xLength; ++i)
        //{
        //    for (int j = 0; j < yLength; ++j)
        //    {
        //        mapArray[i, j] = 0;
        //        Debug.Log(mapArray[i, j]);
        //    }
        //}
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            a.transform.Translate(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            a.transform.Translate(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            a.transform.Translate(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            a.transform.Translate(Vector3.down);
        }
    }
}

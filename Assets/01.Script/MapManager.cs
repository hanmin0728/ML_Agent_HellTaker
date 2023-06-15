using Newtonsoft.Json;
using System.IO;
using UnityEngine;

[System.Serializable]
public class MapArray
{
    public int[] array = new int[9];
}

public class MapManager : MonoBehaviour
{
    public int xLength = 0;
    public int yLength = 0;

    public MapArray[] mapArrays;

    public GameObject a;
    public int x, y = 0;

    public int plusValue = 0;

    public int moveCnt = 0;

    private Data data;
    public Data Data => data;


    private void Start()
    {
        LoadData();
    }
    public bool Clear()
    {
        LoadData();
        if (moveCnt <= data.minMoveCnt)
        {
            data.minMoveCnt = moveCnt;
            SaveData();
            return true;
        }   
        else
        {
            SaveData();
            return false;
        }
    }
    public void LoadData()
    {
        string path = Application.dataPath + "/Save/Data.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = Newtonsoft.Json.JsonConvert.DeserializeObject<Data>(json);
        }
        else
        {
            if (data == null)
            {
                data = new Data();
                data.minMoveCnt = 0;
            }
            File.WriteAllText(path, Newtonsoft.Json.JsonConvert.SerializeObject(data));
        }
    }
    public void SaveData()
    {
        string path = Application.dataPath + "/Save/Data.json";

        string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

        File.WriteAllText(path, json);
    }
    void Update()
    {
//        if (Input.GetKeyDown(KeyCode.D))
//        {
//            plusValue = 1;
//            moveCnt++;

//            if (mapArrays[y].array[x + plusValue] == 1)
//            {
//                a.transform.Translate(Vector3.right);
//                x++;
//                plusValue = 0;
//            }
//            else if (mapArrays[y].array[x + plusValue] == 2)
//            {
//                Debug.Log("끝남");
//            }
//            else
//            {
//                plusValue = 0;
//                Debug.Log("못감 진짜 못감");
//            }
//        }
//        if (Input.GetKeyDown(KeyCode.A))
//        {
//            plusValue = -1;
//            moveCnt++;

//            if (mapArrays[y].array[x + plusValue] == 1)
//            {
//                a.transform.Translate(Vector3.left);
//                x--;
//                plusValue = 0;
//            }
//            else if (mapArrays[y].array[x + plusValue] == 2)
//            {
//                Debug.Log("끝남");
//            }
//            else
//            {
//                plusValue = 0;
//                Debug.Log("못감 진짜 못감");
//            }
//        }
//        if (Input.GetKeyDown(KeyCode.W))
//        {
//            plusValue = 1;
//            moveCnt++;

//            if (mapArrays[y + plusValue].array[x] == 1)
//            {
//                a.transform.Translate(Vector3.up);
//                y++;
//                plusValue = 0;
//            }
//            else if (mapArrays[y + plusValue].array[x] == 2)
//            {
//                Debug.Log("끝남");
//            }
//            else
//            {
//                plusValue = 0;
//                Debug.Log("못감 진짜 못감");
//            }
//        }
//        if (Input.GetKeyDown(KeyCode.S))
//        {
//            plusValue = -1;
//            moveCnt++;

//            if (mapArrays[y + plusValue].array[x] == 1)
//            {
//                a.transform.Translate(Vector3.down);
//                y--;
//                plusValue = 0;
//            }
//            else if (mapArrays[y + plusValue].array[x + plusValue] == 2)
//            {
//                Debug.Log("끝남");
//            }
//            else
//            {
//                plusValue = 0;
//                Debug.Log("못감 진짜 못감");
//            }
//        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI mintext;
    public MapManager m;
    private void Start()
    {
        SetMinText();
    }
    public void SetText()
    {
        text.SetText($"movecnt: {m.moveCnt}");
    }
    public void SetMinText()
    {
        m.LoadData();
        
        mintext.SetText($"minMovecnt: {m.Data.minMoveCnt}");
    }
}

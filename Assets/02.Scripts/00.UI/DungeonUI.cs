 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DungeonUI : MonoBehaviour
{
    public static DungeonUI Instance;
    GameManager gm => GameManager.Instance;
    public Transform pos;
    
    private void Awake()
    {
        Controller.Instacne.transform.position = pos.position;
        if(Instance != null)
        {
            Destroy(gameObject); 
        }
        Instance = this;
        gm.ShowAlert($"스테이지: { gm.nowData.nowStage + 1}");
    }
    private void Start()
    {
        gm.FadeIn();
        gm.PlayBGM(BGMEnum.Dungeon);
    }
    
    

}

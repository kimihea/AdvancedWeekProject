using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    GameManager gm => GameManager.Instance;
    private void Start()
    {
        gm.FadeIn();
        gm.PlayBGM(BGMEnum.TITLE);
    }
    public void StartNewGame()
    {


        gm.MoveScene(1);
        gm.PlaySFX(SFXEnum.UI_CLICK);
    }

}

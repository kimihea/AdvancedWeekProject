using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
    GameManager gm => GameManager.instance;
    private void Start()
    {
        gm.FadeIn();
    }
    public void StartNewGame()
    {
        gm.MoveScene(1);
    }

}

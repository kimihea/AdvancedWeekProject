using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    GameManager gm => GameManager.instance;
    public static MainSceneManager msm;
    private void Awake()
    {
        if(msm != null)
        {
            Destroy(gameObject);
            return;
        }
        msm = this;
    }
   
}

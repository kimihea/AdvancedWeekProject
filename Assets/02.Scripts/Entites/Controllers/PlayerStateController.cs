using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateController : MonoBehaviour
{
    GameManager gm => GameManager.Instance ;
    public float difficulty;
    public void Update()
    {
        gm.nowData.fatigue += Time.deltaTime * difficulty;
        if (gm.nowData.maxFatigue <= gm.nowData.fatigue)
        {
            gm.TheEnd();
            Time.timeScale = 0;
        }
    }
    public void EnterDungeon()
    {
        gm.nowData.fatigue += 10f;
    }
    
}
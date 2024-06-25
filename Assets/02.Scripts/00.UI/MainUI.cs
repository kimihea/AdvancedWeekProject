
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MainUI : MonoBehaviour
{
    GameManager gm => GameManager.Instance;
    //public Transform dungeonOutPos;
    public Transform revivePos;
    public TextMeshProUGUI gold;
    private void Start()
    {
        gm.FadeIn();
       
        gm.PlayBGM(BGMEnum.MAIN);
        Controller.Instacne.transform.position = revivePos.position;
    }
    public void MoveDungeon()
    {
        gm.nowData.fatigue++;
        gm.MoveScene(2);
        gm.PlaySFX(SFXEnum.UI_CLICK);
        Controller.Instacne.state.EnterDungeon();
    }
    public void MoveFarm()
    {
        gm.MoveScene(3);
        gm.PlaySFX(SFXEnum.UI_CLICK);
    }
}

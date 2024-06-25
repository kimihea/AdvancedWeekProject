
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MainUI : MonoBehaviour
{
    GameManager gm => GameManager.Instance;
    //public Transform dungeonOutPos;
    public Transform revivePos;
    public Transform dungeonSign;
    public TextMeshProUGUI gold;
    private void Start()
    {
        gm.FadeIn();      
        gm.PlayBGM(BGMEnum.MAIN);
        Controller.Instacne.transform.position = revivePos.position;
        Controller.Instacne.OnInteractEvent += MoveDungeon;
    }
    public void MoveDungeon()
    {
        Vector2 distance = Controller.Instacne.gameObject.transform.position - dungeonSign.position;
        if (distance.magnitude > 3f) return;
        gm.nowData.fatigue++;
        gm.MoveScene(2);
        gm.PlaySFX(SFXEnum.UI_CLICK);
        Controller.Instacne.state.EnterDungeon();
        Controller.Instacne.OnInteractEvent -= MoveDungeon;
    }
    public void MoveFarm()
    {
        gm.MoveScene(3);
        gm.PlaySFX(SFXEnum.UI_CLICK);
    }
}

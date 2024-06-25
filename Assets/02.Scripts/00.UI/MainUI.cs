
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MainUI : MonoBehaviour
{
    GameManager gm => GameManager.Instance;
    //public Transform dungeonOutPos;
    public Transform revivePos;
    public Transform dungeonSign;
    public Transform farmSign;

    public TextMeshProUGUI gold;
    private void Start()
    {
        gm.FadeIn();      
        gm.PlayBGM(BGMEnum.MAIN);
        Controller.Instacne.transform.position = revivePos.position;
        Controller.Instacne.OnInteractEvent += Move;
    }
    public void Move()
    {
        if(Controller.Instacne.transform.position.x < 5)
        {
            MoveFarm();
        }
        else
        {
            MoveDungeon();
        }
    }
    public void MoveDungeon()
    {
        Vector2 distance = Controller.Instacne.gameObject.transform.position - dungeonSign.position;
        if (distance.magnitude > 5f) return;
        gm.nowData.fatigue++;
        gm.MoveScene(2);
        gm.PlaySFX(SFXEnum.UI_CLICK);
        Controller.Instacne.state.EnterDungeon();
        
    }
    public void MoveFarm()
    {
        Vector2 distance = Controller.Instacne.gameObject.transform.position - farmSign.position;
        if (distance.magnitude > 5f) return;
        gm.MoveScene(3);
        gm.PlaySFX(SFXEnum.UI_CLICK);
    }
    private void OnDestroy()
    {
        Controller.Instacne.OnInteractEvent -= Move;
    }
}

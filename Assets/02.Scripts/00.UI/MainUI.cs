
using UnityEngine;

public class MainUI : MonoBehaviour
{
    GameManager gm => GameManager.Instance;
    private void Start()
    {
        gm.FadeIn();
        gm.PlayBGM(BGMEnum.MAIN);
    }
    public void MoveDungeon()
    {
        gm.MoveScene(2);
        gm.PlaySFX(SFXEnum.UI_CLICK);
    }
    public void MoveFarm()
    {
        gm.MoveScene(3);
        gm.PlaySFX(SFXEnum.UI_CLICK);
    }
}

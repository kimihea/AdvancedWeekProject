using UnityEngine;

public class FaumUI : MonoBehaviour
{
    GameManager gm => GameManager.Instance;
    public Transform pos;

    private void Awake()
    {
        Controller.Instacne.transform.position = pos.position;
        gm.ShowAlert($"마이팜에 입장하였습니다");
    }
    private void Start()
    {
        gm.FadeIn();
        gm.PlayBGM(BGMEnum.MAIN);
    }



}
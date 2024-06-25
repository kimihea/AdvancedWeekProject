using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    GameManager gm => GameManager.Instance;
    public TextMeshProUGUI gold;
    public Image fatigue;
    void Update()
    {
        fatigue.fillAmount = gm.nowData.fatigue/gm.nowData.maxFatigue;
        gold.text  = gm.nowData.Gold.ToString();
    }
}
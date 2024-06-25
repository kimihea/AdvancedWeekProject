using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    GameManager gm => GameManager.Instance;
    public TextMeshProUGUI gold;

    void Update()
    {
        gold.text  = gm.nowData.Gold.ToString();
    }
}
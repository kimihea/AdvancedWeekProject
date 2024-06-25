using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameManager gm => GameManager.Instance;
    [SerializeField]private int value;
    [SerializeField]private ItemData data;
    public void GetMoney()
    {
        gm.nowData.Gold += value;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            if (data.type == ItemType.Gold)
            {
                GetMoney();
                Destroy(gameObject);
            }


    }
}

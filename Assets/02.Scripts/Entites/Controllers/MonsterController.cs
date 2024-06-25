using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private MonsterCondition condition;
    private MonsterStatHandler statHandler;
    public Action OnDamaged;
    public Action Dead;
    private DropItem dropItem;
    public LayerMask hitLayer;
    private bool isDead = false;
    public void Awake()
    {
        condition = GetComponent<MonsterCondition>();
        statHandler= GetComponent<MonsterStatHandler>();
        dropItem = GetComponentInParent<DropItem>();    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isDead) return;
        int collisionLayer = collision.gameObject.layer;

        if (((1 << collisionLayer) & hitLayer.value) != 0)
        {
            float damage = Controller.Instacne.stats.CurrentStat.attackSO.power;
            if (condition.Subtract(damage))
            {
                isDead = true;
                Collider2D collider= GetComponent<Collider2D>();
                collider.enabled = false;
                Dead.Invoke();
                dropItem.Drop();
                Destroy(gameObject,1f);
            }
        }
        OnDamaged?.Invoke();
    }
}

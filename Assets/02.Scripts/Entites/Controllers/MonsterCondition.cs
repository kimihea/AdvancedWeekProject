using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCondition : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public Image uiBar;
    public MonsterStatHandler stat;
    private void Start()
    {
       stat = GetComponent<MonsterStatHandler>();
       maxValue = stat.CurrentStat.maxHealth;
       curValue = maxValue;
    }
    private void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }
    float GetPercentage()
    {
        return curValue / maxValue;
    }
    public bool Subtract(float value)
    {
        curValue -= value;
        if(curValue <= 0)
        {
            return true;
        }
        return false;
    }
}
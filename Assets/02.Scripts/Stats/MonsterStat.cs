using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class MonsterStat
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
}
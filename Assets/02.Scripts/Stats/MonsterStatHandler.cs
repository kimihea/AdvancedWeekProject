using System.Collections.Generic;
using UnityEngine;

public class MonsterStatHandler : MonoBehaviour
{
    [SerializeField] private MonsterStat baseStats;
    public MonsterStat CurrentStat { get; private set; }

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        CurrentStat = new MonsterStat();
        CurrentStat.statsChangeType = baseStats.statsChangeType;
        CurrentStat.maxHealth = baseStats.maxHealth;
        CurrentStat.maxHealth += GameManager.Instance.nowData.nowStage * 2;
    }
}
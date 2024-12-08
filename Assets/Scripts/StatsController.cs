using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    [SerializeField] private LevelsRepositorySo levelsRepositorySo;
    public int LevelsCount => levelsRepositorySo.LevelsStats.Count;
    public LevelSo GetLevelData(int level) => levelsRepositorySo.LevelsStats[level];
    
    public void UpgradeStatsLevel(ReactiveProperty<int> level, ReactiveProperty<int> coinsStat)
    {
        var upgradeCost = GetLevelData(level.Value).UpgradeCost;
        if (coinsStat.Value < upgradeCost)
        {
            return;
        }

        coinsStat.Value -= upgradeCost;
            
        if (level.Value + 1 >= LevelsCount)
            Debug.LogError($"[LevelsRepositorySo][UpgradeStatsLevel] Error: new level is out of range");
        else
            level.Value++;
    }
}

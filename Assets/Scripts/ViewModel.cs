using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;

public class ViewModel : MonoBehaviour
{
    public LevelSo LevelSo => _statsController.GetLevelData(_levelReactive.Value);
    public bool IsEnableUpgrade => _statsController.LevelsCount - 1 > _levelReactive.Value && LevelSo.UpgradeCost <= _coinsReactive.Value;
    public IReadOnlyReactiveProperty<int> LevelReactive => _levelReactive;
    public IReadOnlyReactiveProperty<int> CoinsReactive => _coinsReactive;

    private ReactiveProperty<int> _levelReactive = new();
    private ReactiveProperty<int> _coinsReactive = new(1000000);

    private StatsController _statsController;

    [Inject]
    private void Construct(StatsController statsController)
    {
        _statsController = statsController;
    }

    public void LevelUpClick()
    {
        _statsController.UpgradeStatsLevel(_levelReactive, _coinsReactive);
    }
}

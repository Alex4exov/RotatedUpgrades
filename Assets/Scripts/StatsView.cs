using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class StatsView : MonoBehaviour
{
    [SerializeField] private StatText strengthText;
    [SerializeField] private StatText agilityText;
    [SerializeField] private StatText damageText;
    [SerializeField] private StatText coinsText;
    [SerializeField] private StatText levelText;
    [SerializeField] private StatText costText;
    [SerializeField] private Slider coinsSlider;
    [SerializeField] private Button upButton;
    
    private const string MaxLevelText = "Максимальный уровень";

    private List<IDisposable> _disposables = new();
    private ViewModel _viewModel;

    [Inject]
    private void Construct(ViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.CoinsReactive.Subscribe(UpdateCoinsView).AddTo(_disposables);
        _viewModel.LevelReactive.Subscribe(UpdateStatsView).AddTo(_disposables);
        _viewModel.LevelReactive.Subscribe(v => UpdateButtonView()).AddTo(_disposables);

        coinsSlider.maxValue = _viewModel.CoinsReactive.Value;
        coinsSlider.value = coinsSlider.maxValue;
    }

    private void OnDisable()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }

        _disposables.Clear();
    }
    
    private void UpdateStatsView(int level)
    {
        levelText.SetValue(level + 1);
        
        var levelSo = _viewModel.LevelSo;
        strengthText.SetValue(levelSo.Strength);
        agilityText.SetValue(levelSo.Agility);
        damageText.SetValue(levelSo.Damage);
        costText.SetValue(levelSo.UpgradeCost);
    }
    
    private void UpdateCoinsView(int coins)
    {
        coinsText.SetValue(coins);
        coinsSlider.value = coins;
    }

    private void UpdateButtonView()
    {
        upButton.interactable = _viewModel.IsEnableUpgrade;
        if (!_viewModel.IsEnableUpgrade)
            costText.SetText(MaxLevelText);
    }
}

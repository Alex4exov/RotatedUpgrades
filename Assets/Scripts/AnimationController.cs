using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using VContainer;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    private List<IDisposable> _disposables = new();
    private ViewModel _viewModel;
    private readonly int _level = Animator.StringToHash("Level");

    [Inject]
    private void Construct(ViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.LevelReactive.Subscribe(UpdateAnimation).AddTo(_disposables);
    }
    
    private void OnDisable()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }

        _disposables.Clear();
    }
    
    private void UpdateAnimation(int level) => animator.SetInteger(_level, level);
}

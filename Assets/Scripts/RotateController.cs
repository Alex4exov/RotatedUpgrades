using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform unityChan;

    private bool _isDowned = false;
    private float _prevPosX;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_isDowned)
        {
            Rotate();
        }
    }

    public void OnClickDown(InputAction.CallbackContext context)
    {
        _isDowned = context.ReadValue<float>() == 1;
        if (_isDowned)
            _prevPosX = _camera.ScreenToViewportPoint(Pointer.current.position.ReadValue()).x;
    }

    private void Rotate()
    {
        var newPosX = _camera.ScreenToViewportPoint(Pointer.current.position.ReadValue()).x;
        var rotationAng = (newPosX - _prevPosX) * rotationSpeed;
        _prevPosX = newPosX;
        unityChan.Rotate(Vector3.up, rotationAng);
    }
}

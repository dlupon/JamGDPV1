using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class PlayerInput : Brain
{
    // Components
    private InputManager _input;
    
    // Camera
    private Transform _cameraTransform;
    private Vector3 _cameraRotation;
    private Quaternion _inputRotatationByCamera;


    protected override void SetComponents()
    {
        base.SetComponents();
        _input = GetComponent<InputManager>();
        _cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        WaitForInputAction();
    }

    private void WaitForInputAction()
    {
        _cameraRotation = _cameraTransform.rotation.eulerAngles;
        _cameraRotation.x = 0;
        _inputRotatationByCamera = Quaternion.Euler(_cameraRotation);
        _inputDirection = _inputRotatationByCamera * _input.Direction ;
    }
}

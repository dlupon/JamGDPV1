using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InputManager))]
public class PlayerInput : Brain
{
    // Components
    private InputManager _input;

    // Event
    public UnityEvent OnLeftClickDown = new UnityEvent();

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
        UpdateInput();
    }

    private void UpdateInput()
    {
        UpdateInputDirection();
        if (Input.GetMouseButtonDown(0)) OnLeftClickDown.Invoke();
    }

    private void UpdateInputDirection()
    {
        _cameraRotation = _cameraTransform.rotation.eulerAngles;
        _cameraRotation.x = 0;
        _inputRotatationByCamera = Quaternion.Euler(_cameraRotation);
        _inputDirection = _inputRotatationByCamera * _input.Direction;
    }
}

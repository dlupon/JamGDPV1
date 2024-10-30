using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class PlayerInput : Brain
{
    // Components
    private InputManager _input;

    private void Awake()
    {
        _input = GetComponent<InputManager>();
    }

    void Update()
    {
        WaitForInputAction();
    }

    private void WaitForInputAction()
    {
        _inputDirection = _input.Direction;
    }
}

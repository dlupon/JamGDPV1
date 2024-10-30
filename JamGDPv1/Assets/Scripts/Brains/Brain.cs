using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    // Getters
    public Vector3 InputDirection { get => _inputDirection; }
    public Vector3 InputRotation { get => _inputRotation; }

    // Component
    protected Transform _transform;

    // Inputs
    protected Vector3 _inputDirection;
    protected Vector3 _inputRotation;

    private void Awake()
    {
        SetComponents();
    }

    protected virtual void SetComponents()
    {
        _transform = GetComponent<Transform>();
    }
}

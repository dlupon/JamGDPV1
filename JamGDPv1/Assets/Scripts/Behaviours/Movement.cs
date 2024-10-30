using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movement : Behaviour
{
    // Component
    private Rigidbody _rigidBodu;

    // Movement Properties
    [SerializeField] private float _speed = 10;
    private Vector3 _acceleration = Vector3.zero;

    protected override void SetComponents()
    {
        base.SetComponents();
        _rigidBodu = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _acceleration = _brain.InputDirection * _speed;
        _rigidBodu.velocity = _acceleration;
    }
}

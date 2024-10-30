using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    // Getters
    public Vector3 InputDirection { get => _inputDirection; }

    // Inputs
    protected Vector3 _inputDirection;
}

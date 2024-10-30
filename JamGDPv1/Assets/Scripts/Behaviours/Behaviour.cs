using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Behaviour : MonoBehaviour
{
    // Components
    protected Brain _brain = null;
    protected Transform _transform;


    protected void Awake()
    {
        SetComponents();
        SetProperties();
    }

    protected virtual void SetComponents()
    {
        if (TryGetComponent<Brain>(out _brain));
        _transform = GetComponent<Transform>();
    }

    protected virtual void SetProperties() { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Brain))]
public class Behaviour : MonoBehaviour
{
    // Components
    protected Brain _brain;
    protected Transform _transform;


    protected void Awake()
    {
        SetComponents();
    }

    protected virtual void SetComponents()
    {
        _brain = GetComponent<Brain>();
        _transform = GetComponent<Transform>();
    }
}

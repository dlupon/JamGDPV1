using UnityEngine;
using UnityEngine.Events;

public class Brain : MonoBehaviour
{
    // Getters
    public Vector3 InputDirection { get => _inputDirection; }
    public Vector3 InputRotation { get => _inputRotation; }

    // Events
    public UnityEvent OnMainActionDown = new UnityEvent();
    public UnityEvent OnMainActionHold = new UnityEvent();
    public UnityEvent OnMainActionUp = new UnityEvent();
    public UnityEvent OnSecondaryActionDown = new UnityEvent();
    public UnityEvent OnSecondaryActionHold = new UnityEvent();
    public UnityEvent OnSecondaryActionUp = new UnityEvent();

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

using System;
using UnityEditor.TerrainTools;
using UnityEngine;

public class PickUp : Behavior
{

    // Components
    private Rigidbody _rigidBody;

    // Lift
    [SerializeField] private string _litableTag;
    [SerializeField] private Vector3 _litabletargetPosition = new Vector3(0, 3, 0);
    [SerializeField] private float _maxLiftDistance = 1.5f;
    [SerializeField] private float _maxLiftForce = 100f;
    [SerializeField] private float _litableDrag = 20f;
    private Transform _liftableTransform = null;
    private Rigidbody _liftableRigidBody = null;
    private float _liftableDefaultDrag;
    private Vector3 _liftToTargetPosition;
    private Vector3 _distanceToLiftable;
    private Action DoLiftOrVoid;

    // Raycast
    [SerializeField] private float _raycasrYOffset = 1f;
    [SerializeField] private float _raycasrLength = 3f;


    private void Start() => SetModeVoid();

    private void FixedUpdate() => DoLiftOrVoid();

    protected override void SetComponents()
    {
        base.SetComponents();
        _rigidBody = GetComponent<Rigidbody>();
    }

    protected override void ConnectBrain() => _brain.OnMainActionDown.AddListener(TryPickUp);

    private void TryPickUp()
    {
        print("Click");
        RaycastHit lRaycastInfo;
        if (!Physics.Raycast(_transform.position + Vector3.up * _raycasrYOffset, _transform.forward, out lRaycastInfo, _raycasrLength)) return;
        if (lRaycastInfo.collider.tag != _litableTag) return;
        PickUpObject(lRaycastInfo.collider.gameObject);
    }

    private void PickUpObject(GameObject pLiftable)
    {
        print("Pick");
        _liftableTransform = pLiftable.transform;
        _liftableRigidBody = pLiftable.GetComponent<Rigidbody>();
        _liftableDefaultDrag = _liftableRigidBody.drag;
        _liftableTransform.position = _transform.position + _transform.rotation * _litabletargetPosition;
        _liftableRigidBody.drag = _litableDrag;
        SetModeLift();
    }

    private void SetModeVoid() => DoLiftOrVoid = DoVoid;

    private void SetModeLift() => DoLiftOrVoid = DoLift;

    private void DoVoid() { print("Void"); }

    private void DoLift()
    {
        print("Lift");
        PutLiftableOnTop();
        _liftableRigidBody.AddForce(_liftToTargetPosition * _maxLiftForce, ForceMode.Force);
        if (_liftToTargetPosition.magnitude < _maxLiftDistance) return;
        Vector3 lCounterForce = -_liftToTargetPosition; lCounterForce.y = 0;
        _rigidBody.AddForce(lCounterForce * _maxLiftForce, ForceMode.Force);
        
    }

    private void PutLiftableOnTop()
    {
        _liftToTargetPosition =_transform.position + _transform.rotation * _litabletargetPosition - _liftableTransform.position;

    }
}

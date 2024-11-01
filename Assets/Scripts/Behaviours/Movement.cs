using UnityEngine;

public class Movement : Behavior
{
    // Component
    private Rigidbody _rigidBody;

    // Gavity
    [SerializeField] private float _gravityStrength = 2;
    [SerializeField] private float _maxGravityStrength = 30f;
    private Vector3 _gravityDirection = Vector3.down;
    private Vector3 _gravityForce = Vector3.down;

    // Movement Properties
    [SerializeField] private float _speed = 10;
    private Vector3 _acceleration = Vector3.zero;

    // Ground Raycast
    [SerializeField] private float _groundRaycastLength = 1f;
    public bool _isGrounded = false;
    private RaycastHit _groundRaycastInfo;

    // Rotation Properties
    [SerializeField] private float _angularSpeed = .5f;
    [SerializeField] private float _angularInputTolerance = .3f;

    private void FixedUpdate()
    {
        GroundCheck();
        MovementForce();
        GravityForce();
        ApplyForces();
        AngularMotion();
    }
    protected override void SetComponents()
    {
        base.SetComponents();
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void MovementForce() => _acceleration = _brain.InputDirection.magnitude > .9f ? _brain.InputDirection * _speed * 10 : - _rigidBody.velocity * 10f;

    private void GravityForce()
    {
        if (_isGrounded) { _gravityForce = _gravityDirection * _gravityStrength; return;  }
        if (_gravityForce.magnitude > _maxGravityStrength) { _gravityForce = _gravityDirection * _maxGravityStrength; return; }
        _gravityForce += _gravityDirection * _gravityStrength;
    }

    private void GroundCheck() => _isGrounded = Physics.Raycast(_transform.position + _rigidBody.centerOfMass, Vector3.down, out _groundRaycastInfo, _groundRaycastLength);
    
    private void ApplyForces()
    {
        _rigidBody.AddForce(_acceleration, ForceMode.Force);
        _rigidBody.AddForce(_gravityForce, ForceMode.Force);
        LimiteMotion();
    }

    private void LimiteMotion()
    {
        Vector3 lVelocity = _rigidBody.velocity; lVelocity.y = 0;
        if (lVelocity.magnitude <= _speed) return;
        _rigidBody.velocity = lVelocity.normalized * _speed + Vector3.up * _rigidBody.velocity.y;
    }

    private void AngularMotion()
    {
        if (_brain.InputDirection.magnitude < _angularInputTolerance) return;
        Quaternion lWantedRotation = Quaternion.LookRotation(_brain.InputDirection, Vector3.up);
        _transform.rotation = Quaternion.Slerp(_transform.rotation, lWantedRotation, _angularSpeed);
    }
}

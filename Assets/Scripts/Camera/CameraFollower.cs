using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    // Component
    private Transform _transform;
    [SerializeField] private Transform _targetPath;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _transform.position += (_targetPath.position - _transform.position) * .1f;
    }
}

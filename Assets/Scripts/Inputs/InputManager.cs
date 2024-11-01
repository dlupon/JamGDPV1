using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Inputs
    private const string INPUT_HORIZONTAL = "Horizontal";
    private const string INPUT_VECTICAL = "Vertical";

    // Getters
    public Vector3 Direction { get => getDirection(); }

    // Utilities
    private Vector3 _vectorInput = Vector3.zero;

    private Vector3 getDirection()
    {
        _vectorInput.x = Input.GetAxisRaw(INPUT_HORIZONTAL);
        _vectorInput.z = Input.GetAxisRaw(INPUT_VECTICAL);
        return _vectorInput;
    }
}

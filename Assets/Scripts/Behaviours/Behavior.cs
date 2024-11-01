using UnityEngine;

public class Behavior : MonoBehaviour
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
        if (TryGetComponent<Brain>(out _brain)) ConnectBrain();
        _transform = GetComponent<Transform>();
    }

    protected virtual void SetProperties() { }

    public void SetBrain(Brain pbrain)
    { 
        _brain = pbrain;
        ConnectBrain();
    }

    protected virtual void ConnectBrain()
    {

    }
}

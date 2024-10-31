using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCatcher : Behavior
{
    // Brian
    private PlayerInput _brain;

    // Entity Detection
    [SerializeField] private float detectionRange = 3f;

    protected override void SetComponents()
    {
        base.SetComponents();
        _brain = GetComponent<PlayerInput>();
    }

    private void Start() => ConnectEvent();

    private void ConnectEvent()
    {
        _brain.OnLeftClickDown.AddListener(CheckEntity);
    }

    private void CheckEntity()
    {
        print("Check Entity");
        RaycastHit lHitInfo;
        bool lEntityDetected = Physics.Raycast(_transform.position + Vector3.up, _transform.forward, out lHitInfo, detectionRange);
        if (!lEntityDetected) return;
        ChangeCorps(lHitInfo.collider.gameObject);
    }

    private void ChangeCorps(GameObject pEntity)
    {
        print("YOOOO");
        Brain pNewBrain = pEntity.AddComponent<PlayerInput>();

        foreach (Behavior lCurrentBehavior in pEntity.GetComponents<Behavior>())
            lCurrentBehavior.SetBrain(pNewBrain);
        gameObject.SetActive(false);
    }
}
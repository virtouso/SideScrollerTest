using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAiStateMachine : MonoBehaviour
{

    protected Transform CachedTransform;
    protected Action CurrentState { get; set; }

    protected Transform CachedEnemyTransform;
    protected void Awake()
    {
        CachedTransform = transform;
    }

    protected virtual void Update()
    {
        if (GeneralReferences.Paused) return;
        CurrentState?.Invoke();
    }
}
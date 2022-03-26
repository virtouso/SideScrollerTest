using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAiStateMachine : MonoBehaviour
{
    protected Action CurrentState { get; set; }


    protected virtual void Update()
    {
        CurrentState?.Invoke();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Zenject;

public class BasicShooterAi : BaseAiStateMachine
{
    [Inject] private IDamageable _damageable;

    [SerializeField] private int _initialHealth;
    
    private LayerMask _wallDetectionMask;
    private LayerMask _enemyDetectionMask;
    private LayerMask _paddleDetectionMask;

    private void Patrol()
    {
        
    }

    private void Attack()
    {
        
    }

    private void Start()
    {
        _damageable.Init(_initialHealth);
    }
}
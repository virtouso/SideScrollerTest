using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Zenject;

public class BasicShooterAi : BaseAiStateMachine
{
    [Inject] private IDamageable _damageable;
    [Inject] private IBullet.Pool _bulletPool;
    [Inject] private IActorGroup _actor;

    [SerializeField] private int _initialHealth;
    [SerializeField] private float _fireRate;

    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _wallDetectionMask;
    [SerializeField] private LayerMask _enemyDetectionMask;
    [SerializeField] private LayerMask _paddleDetectionMask;

    [SerializeField] private Vector2 _boxDetectionSize;
    [SerializeField] private float _obstacleDetectionDistance;
    [SerializeField] private float _enemyDetectionDistance;
    [SerializeField] private Transform _shootMuzzle;

    private void Patrol()
    {
        CachedTransform.position += CachedTransform.right * _speed * Time.deltaTime;
        bool wallDetected = DetectWall();
        bool paddleDetected = DetectPaddle();
        bool enemyDetected = DetectEnemy();
        if (wallDetected || paddleDetected)
        {
            CachedTransform.Rotate(Vector3.up, 180);
        }

        if (enemyDetected)
            CurrentState = Attack;
    }


    private float _shootTimer;

    private void Attack()
    {
        if (CachedEnemyTransform.position.x > CachedTransform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (CachedEnemyTransform.position.x < CachedTransform.position.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);

        _shootTimer += Time.deltaTime;

        if (_shootTimer >= _fireRate)
        {
      
            _shootTimer = 0;
            var bullet = _bulletPool.Spawn();
            bullet.Shoot(_shootMuzzle.position, _shootMuzzle.right, 0, _actor);
        }
    }


    private bool DetectWall()
    {
        return Physics2D.BoxCast(CachedTransform.position,
            _boxDetectionSize, 0, CachedTransform.right,
            _obstacleDetectionDistance, _wallDetectionMask);
    }

    private bool DetectPaddle()
    {
        return Physics2D.BoxCast(CachedTransform.position,
            _boxDetectionSize, 0, CachedTransform.right,
            _obstacleDetectionDistance, _paddleDetectionMask);
    }

    private bool DetectEnemy()
    {
        var result = Physics2D.BoxCast(CachedTransform.position,
            _boxDetectionSize, 0, CachedTransform.right,
            _enemyDetectionDistance, _enemyDetectionMask);
        CachedEnemyTransform = result.transform;
        return result;
    }


    private void Start()
    {
        _damageable.Init(_initialHealth);
        _damageable.OnDeath += delegate { gameObject.SetActive(false); };
        CurrentState = Patrol;
    }
}
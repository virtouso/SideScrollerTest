using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.Common.Locks;
using UnityEngine;
using Zenject;

public interface IBullet
{
    public class Pool : MemoryPool<IBullet>
    {
    }

    void Shoot(Vector3 startPosition, Vector3 direction, float angleRotation, IActorGroup ownerActor);
}

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _shootForce;
    [SerializeField] private DamagerTypes _damagerType;
    [SerializeField] private int _damage;
    private IActorGroup _actor;


    public void Shoot(Vector3 startPosition, Vector3 direction, float angleRotation, IActorGroup ownerActor)
    {
        transform.position = startPosition;
        _rigidBody.AddForce(_shootForce * direction, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //todo fix it
        var component = other.GetComponent<Damageable>();
        if (component != null) ;
        component.ApplyDamage(_damage, _damagerType, _actor);
    }
}
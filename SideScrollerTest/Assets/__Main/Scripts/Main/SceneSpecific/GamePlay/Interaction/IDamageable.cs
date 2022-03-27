using System;
using System.Collections;
using System.Collections.Generic;
using MVVM;
using UnityEngine;



public interface IDamageable
{
    Model<int> CurrentHealth { get; set; }
    Model<int> CurrentArmour { get; set; }
    Action<IActorGroup> OnGetShot { get; set; }
    DamageableTypes DamageableType { get; }
    void Init(int healthAmount);
    void ApplyDamage(int damageAmount,DamagerTypes damagerType, IActorGroup shooterGroup);
    Action OnDeath { get; set; }
}
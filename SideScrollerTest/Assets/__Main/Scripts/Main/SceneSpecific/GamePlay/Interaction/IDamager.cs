using System.Collections;
using System.Collections.Generic;
using MVVM;
using UnityEngine;

public interface IDamager
{
    Model<int> DamageAmount { get; set; }
    DamagerTypes DamagerType { get; }
    void Init(int initialDamage);
    void ApplyDamage(IDamageable damageable, IActorGroup shooterGroup);
}
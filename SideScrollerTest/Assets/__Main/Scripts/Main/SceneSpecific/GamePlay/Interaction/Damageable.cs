using System;
using MVVM;
using UnityEngine;
using Zenject;

public class Damageable : MonoBehaviour, IDamageable
{
    [Inject] private IEnvironmentInteractionManager _environmentInteractionManager;
    [Inject] private IActorGroup _myActorGroup;

    
    public Model<int> CurrentHealth { get; set; }
    public Model<int> CurrentArmour { get; set; }

    [SerializeField] private DamageableTypes _damageableType;
    public Action<IActorGroup> OnGetShot { get; set; }
    public DamageableTypes DamageableType => _damageableType;

    public void Init(int healthAmount, int armourAmount)
    {
        CurrentHealth = new Model<int>(healthAmount);
        CurrentHealth = new Model<int>(armourAmount);
    }

    public void  ApplyDamage(int damageAmount,DamagerTypes damagerType, IActorGroup shooterGroup)
    {
       
        if (!_environmentInteractionManager.FriendlyFire)
            if (_myActorGroup.ActorGroup == shooterGroup.ActorGroup)
                return;
        
        
        if (!_environmentInteractionManager.DamageIsApplicable(damagerType, _damageableType))
            return;
        CurrentHealth.Data -= damageAmount;
        OnGetShot?.Invoke(shooterGroup);
        if (CurrentHealth.Data <= 0)
            OnDeath.Invoke();
    }

    public Action OnDeath { get; set; }


  
}
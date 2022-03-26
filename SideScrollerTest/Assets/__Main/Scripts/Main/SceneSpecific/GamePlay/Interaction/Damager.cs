
using MVVM;
using UnityEngine;

public class Damager : MonoBehaviour, IDamager
{
    public Model<int> DamageAmount { get; set; }

    [SerializeField] private DamagerTypes _damagerType;
    public DamagerTypes DamagerType => _damagerType;


    public void Init(int initialDamage)
    {
        DamageAmount = new Model<int>(initialDamage);
    }

    public void ApplyDamage(IDamageable damageable, IActorGroup shooterActorGroup)
    {
       damageable.ApplyDamage(DamageAmount.Data, _damagerType, shooterActorGroup);
    }
}
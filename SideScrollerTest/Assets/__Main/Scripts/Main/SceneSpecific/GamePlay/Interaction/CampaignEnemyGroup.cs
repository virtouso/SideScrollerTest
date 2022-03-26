using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CampaignEnemyGroup : MonoBehaviour,IActorGroup
{
    [Inject] private IDamageable _damageable;
    public int Health => _damageable.CurrentHealth.Data;
    public ActorGroups ActorGroup => ActorGroups.CampaignEnemy;
    public Transform Transform => transform;
    public string Name => name;

}

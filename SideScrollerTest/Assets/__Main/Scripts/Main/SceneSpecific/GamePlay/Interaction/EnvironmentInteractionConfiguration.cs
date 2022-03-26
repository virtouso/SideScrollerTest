using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnvironmentInteractionConfiguration : ScriptableObject, IEnvironmentInteractionConfiguration
{
    [SerializeField] private bool _friendlyFire;
    public bool FriendlyFire => _friendlyFire;

    
    
    [SerializeField] private List<DamagerDamageableListPair> _damagingConfigurationList;

    private Dictionary<DamagerTypes, DamageableTypes[]> _damagingConfiguration;


    public Dictionary<DamagerTypes, DamageableTypes[]> DamagingConfiguration
    {
        get
        {
            if (_damagingConfiguration == null)
            {
                _damagingConfiguration =
                    new Dictionary<DamagerTypes, DamageableTypes[]>(_damagingConfigurationList.Count);

                foreach (var item in _damagingConfigurationList)
                {
                    _damagingConfiguration.Add(item.DamagerType, item.DamageableTypes);
                }
            }

            return _damagingConfiguration;
        }
    }
}
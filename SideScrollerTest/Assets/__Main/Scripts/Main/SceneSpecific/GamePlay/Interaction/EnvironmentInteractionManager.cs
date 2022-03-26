using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class EnvironmentInteractionManager : MonoBehaviour,IEnvironmentInteractionManager
{
    [Inject] private IEnvironmentInteractionConfiguration _environmentInteractionConfiguration;
    
    public bool DamageIsApplicable(DamagerTypes damagerType, DamageableTypes damageableType)
    {
        if (_environmentInteractionConfiguration.DamagingConfiguration[damagerType].Contains(damageableType))
            return true;
        return false;
    }

    public bool FriendlyFire => _environmentInteractionConfiguration.FriendlyFire;
}

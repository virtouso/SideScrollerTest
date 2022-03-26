using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnvironmentInteractionConfiguration 
{
  bool FriendlyFire { get; }
    Dictionary<DamagerTypes, DamageableTypes[]> DamagingConfiguration { get; }

}

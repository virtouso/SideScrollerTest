using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnvironmentInteractionManager
{
  bool DamageIsApplicable(DamagerTypes damagerType, DamageableTypes damageableType);
  bool FriendlyFire { get; }
}

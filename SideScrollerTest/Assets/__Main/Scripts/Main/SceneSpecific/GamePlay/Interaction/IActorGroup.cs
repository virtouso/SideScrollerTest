using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActorGroup
{
  ActorGroups ActorGroup { get; }
  
  Transform Transform { get; }
  
  string Name { get; }
  
  
  int Health { get; }
  
}

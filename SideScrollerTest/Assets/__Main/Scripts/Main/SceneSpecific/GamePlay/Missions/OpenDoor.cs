using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Elements;
using SinglePlayer.OnFoot.Missions;
using UnityEngine;

namespace GamePlay.Missions
{
    public interface IOpenDoor
    {
    }

    public class OpenDoor : MissionBase, IOpenDoor
    {
        [SerializeField] private Door _door;

        private void Start()
        {
            _door.DoorOpened += OnDone;
        }
    }
}
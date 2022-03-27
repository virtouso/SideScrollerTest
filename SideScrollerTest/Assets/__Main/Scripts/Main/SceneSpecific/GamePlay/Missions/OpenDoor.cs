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
        public override void OnChunkFinish()
        {
            base.OnChunkFinish();
            
            gameObject.SetActive(false);
        }

        private void Awake()
        {
       
        }

        private void Start()
        {
          //  _door.DoorOpened += OnDone;

        
          _door.DoorOpened += RunOnDone;
        }


        private void RunOnDone()
        {
            OnDone?.Invoke();
        }
        
        
    }
}
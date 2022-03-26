using System;
using GamePlay.Manager;
using Manager.SinglePlayer;
using Manager.SinglePlayer.Missions;
using SinglePlayer.OnFoot.Missions;
using UnityEngine;
using Zenject;


namespace GamePlay.Missions
{


    public class KillPerson : MissionBase
    {



        [Inject] private ISinglePlayerMissionsManager _missionManager;

        [Inject] private IDamageable _damageable;


        private void OnMissionStart()
        {

        }


        private void OnDeath()
        {
            OnDone?.Invoke();
        }

        private void Start()
        {
            OnStart += OnMissionStart;
            _damageable.OnDeath += OnDeath;
        }
    }
}
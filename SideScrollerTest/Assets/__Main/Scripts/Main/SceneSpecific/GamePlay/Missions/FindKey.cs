using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Elements;
using SinglePlayer.OnFoot.Missions;
using UnityEngine;


namespace GamePlay.Missions
{
    public interface IFindKey{}
    public class FindKey : MissionBase,IFindKey
    {
        [SerializeField] private Key _key;


        private void Start()
        {
            _key.KeyGained += OnDone;
        }
    }
}
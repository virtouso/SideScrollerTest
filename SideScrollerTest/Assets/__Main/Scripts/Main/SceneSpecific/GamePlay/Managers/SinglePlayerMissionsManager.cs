using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamePlay.Missions;
using Manager.SinglePlayer.Missions;
using SinglePlayer.OnFoot.Missions;
using UnityEngine;
using Zenject;

namespace GamePlay.Manager
{
    public interface ISinglePlayerMissionsManager
    {
        public Action<MissionBase> OnMissionFail { get; set; }
        public Action<MissionBase> OnMissionSuccess { get; set; }


        public Action<MissionsList.MissionChunk> OnMissionChunkStart { get; set; }
        public Action<MissionsList.MissionChunk> OnMissionChunkSuccess { get; set; }
        public Action<MissionsList.MissionChunk> OnMissionChunkFail { get; set; }


        public Action<string> OnLevelStart { get; set; }
        public Action<string> OnLevelSuccess { get; set; }
        public Action<string> OnLevelFail { get; set; }
    }


    public class SinglePlayerMissionsManager : MonoBehaviour, ISinglePlayerMissionsManager
    {
       [Inject] private IGamePlayUiManager _uiManager;


        public Action<MissionBase> OnMissionFail { get; set; }
        public Action<MissionBase> OnMissionSuccess { get; set; }

        public Action<MissionsList.MissionChunk> OnMissionChunkStart { get; set; }
        public Action<MissionsList.MissionChunk> OnMissionChunkSuccess { get; set; }
        public Action<MissionsList.MissionChunk> OnMissionChunkFail { get; set; }
        public Action<string> OnLevelStart { get; set; }
        public Action<string> OnLevelSuccess { get; set; }
        public Action<string> OnLevelFail { get; set; }


        private void Start()
        {
            OnMissionFail += delegate(MissionBase mission) { _uiManager.ShowMissionFailMessage(mission.FailMessage); };
            OnMissionSuccess += delegate(MissionBase mission)
            {
                _uiManager.ShowMissionSuccessMessage(mission.SuccessMessage);
            };
            OnMissionChunkStart += delegate(MissionsList.MissionChunk chunk)
            {
                _uiManager.ShowMissionChunkMessage(chunk.ChunkMessage);
            };
            OnMissionChunkSuccess += delegate(MissionsList.MissionChunk chunk)
            {
                _uiManager.ShowMissionChunkSuccessMessage(chunk.FinalSuccessMessage);
            };
            OnMissionChunkFail += delegate(MissionsList.MissionChunk chunk)
            {
                _uiManager.ShowMissionChunkFailMessage(chunk.FinalFailureMessage);
            };
            
            OnLevelStart += delegate(string s) { _uiManager.ShowLevelStartMessage(s); };
            OnLevelSuccess += delegate(string s) { _uiManager.ShowLevelSuccessMessage(s); };
            OnLevelFail += delegate(string s) { _uiManager.ShowLevelFailMessage(s); };
            
 
        }


 
        
        
        
    }
}
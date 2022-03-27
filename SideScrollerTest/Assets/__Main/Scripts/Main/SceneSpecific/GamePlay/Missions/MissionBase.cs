using System;
using System.Collections;
using System.Collections.Generic;
using Manager.SinglePlayer.Missions;
using UnityEngine;
using UnityEngine.Events;


namespace SinglePlayer.OnFoot.Missions
{
    public abstract class MissionBase : MonoBehaviour
    {
        [SerializeField] private MissionTypes _missionType;
        public MissionTypes MissionType => _missionType;

        [SerializeField] private MissionPriorityType _missionPriority;
        public MissionPriorityType MissionPriority => _missionPriority;

        [SerializeField] private MissionGroupId missionGroupId;
        public MissionGroupId MissionGroupId => missionGroupId;

        [SerializeField] private MissionGroupId requirementGroupId;
        public MissionGroupId RequirementGroupId => requirementGroupId;

        [SerializeField] private bool _loseIsFata;
        public bool LoseIsFatal => _loseIsFata;

        [SerializeField] private bool _successIsFinal;
        public bool SuccessIsFinal => _successIsFinal;

        [SerializeField] private bool _successIsAggregator;
        public bool SuccessIsAggregator => _successIsAggregator;

        [SerializeField] private bool _failIsAggregator;
        public bool FailIsAggregator => _failIsAggregator;


        public Action OnFail { get; set; }
        public Action OnStart { get; set; }
        public Action OnDone { get; set; }


        [SerializeField] private MissionBase.MissionTime _missionTimer;
        public MissionBase.MissionTime MissionTimer => _missionTimer;

        [SerializeField] private string _successMessage;
        public string SuccessMessage => _successMessage;

        [SerializeField] private string _failMessage;
        public string FailMessage => _failMessage;

        [SerializeField] private string _desciption;
        public string Description => _desciption;

        public virtual void OnChunkFinish()
        {
            gameObject.SetActive(false);
        }


        protected (int, int) GetTime(int time)
        {
            int minute = time / 60;
            int second = time % 60;

            return (minute, second);
        }

        [System.Serializable]
        public class MissionTime
        {
            public bool TimeLimited;
            public int Time;
        }
    }
}
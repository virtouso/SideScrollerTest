using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Manager;
using Manager.SinglePlayer;
using Manager.SinglePlayer.Missions;
using SinglePlayer.OnFoot.Missions;
using UnityEngine;
using Zenject;

namespace GamePlay.Missions
{
    public interface IMissionsList
    {
    }

    public class MissionsList : MonoBehaviour, IMissionsList
    {
        [Inject] private ISinglePlayerMissionsManager _missionsManager;

        [SerializeField] private string _levelDescriptionMessage;
        [SerializeField] private string _levelSuccessMessage;
        [SerializeField] private string _levelFailMessage;
        [SerializeField] private float _timeBeforeStartFirstChunk;
        [SerializeField] private List<MissionChunk> _missionChunks;

        private int _currentMissionChunk = -1;


        protected virtual IEnumerator StartLevel()
        {
            yield return new WaitForSeconds(_timeBeforeStartFirstChunk);
            _missionsManager.OnLevelStart.Invoke(_levelDescriptionMessage);
            StartCoroutine(StartNewMissionChunk());
        }

        protected virtual void OnLevelFail()
        {
            _missionsManager.OnLevelFail.Invoke(_levelSuccessMessage);
        }


        protected virtual void OnLevelSuccess()
        {
            _missionsManager.OnLevelSuccess.Invoke(_levelFailMessage);
        }


        private IEnumerator StartNewMissionChunk()
        {
            if (_currentMissionChunk >= _missionChunks.Count - 1)
            {
                OnLevelSuccess();
                yield break;
            }


            _currentMissionChunk++;
            yield return new WaitForSeconds(_missionChunks[_currentMissionChunk].TimeBeforeStartChunk);
            _missionChunks[_currentMissionChunk].StartMissionChunk();
            _missionsManager.OnMissionChunkStart.Invoke(_missionChunks[_currentMissionChunk]);

            _missionsManager.OnMissionChunkSuccess += delegate(MissionChunk chunk)
            {
                _missionChunks[_currentMissionChunk].OnFinalSuccess.Invoke();
            };

            _missionsManager.OnMissionChunkFail += delegate(MissionChunk chunk)
            {
                _missionChunks[_currentMissionChunk].OnFinalFail.Invoke();
            };
        }

        private void Start()
        {
            _missionsManager.OnLevelStart += delegate(string s) { StartLevel(); };


            foreach (var item in _missionChunks)
            {
                item.Init();
                item.OnFinalFail += OnLevelFail;
                item.OnFinalSuccess += delegate { StartCoroutine(StartNewMissionChunk()); };
            }
        }

        [System.Serializable]
        public class MissionChunk
        {
            public float TimeBeforeStartChunk;

            public string ChunkMessage;

            public bool AggregateSuccess;
            public int NumberOfSuccessToWin;
            private int _successCounter;
            public string FinalSuccessMessage;

            public bool AggregateFailure;
            public int NumberOfFailToLose;
            private int _failureCounter;
            public string FinalFailureMessage;

            public MissionGroupId MissionGroupId;
            public List<MissionBase> Missions;

            public void Init()
            {
                foreach (var item in Missions)
                {
                    if (item.SuccessIsAggregator)
                        item.OnDone += AggregateSuccessNumber;
                    if (item.FailIsAggregator)
                        item.OnFail += AggregateFailureNumber;

                    if (item.SuccessIsFinal)
                        item.OnDone += OnFinalSuccess;

                    if (item.LoseIsFatal)
                        item.OnFail += OnFinalFail;

                    item.gameObject.SetActive(false);
                }
            }


            public void StartMissionChunk()
            {
                foreach (var item in Missions)
                {
                    item.gameObject.SetActive(true);
                }
            }


            public Action OnFinalSuccess;
            public Action OnFinalFail;


            private void AggregateSuccessNumber()
            {
                if (!AggregateSuccess) return;
                _successCounter++;

                if (_successCounter >= NumberOfSuccessToWin)
                {
                    OnFinalSuccess?.Invoke();
                    foreach (var item in Missions)
                    {
                        item.OnChunkFinish();
                    }
                }
            }

            private void AggregateFailureNumber()
            {
                if (!AggregateFailure) return;
                _failureCounter++;

                if (_failureCounter >= NumberOfFailToLose)
                {
                    OnFinalFail?.Invoke();
                    foreach (var item in Missions)
                    {
                        item.OnChunkFinish();
                    }
                }
            }
        }
    }
}
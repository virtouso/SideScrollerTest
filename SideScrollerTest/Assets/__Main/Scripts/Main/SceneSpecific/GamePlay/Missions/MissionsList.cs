using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamePlay.Manager;
using Manager.SinglePlayer;
using Manager.SinglePlayer.Missions;
using SinglePlayer.OnFoot.Missions;
using UnityEngine;
using UnityEngine.Events;
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
            //      Task.Delay(2000);

            _missionsManager.OnLevelStart.Invoke(_levelDescriptionMessage);
            StartCoroutine(StartNewMissionChunk());
        }

        protected virtual void OnLevelFail()
        {
            _missionsManager.OnLevelFail.Invoke(_levelFailMessage);
        }


        protected virtual void OnLevelSuccess()
        {
            _missionsManager.OnLevelSuccess.Invoke(_levelSuccessMessage);
            Debug.Log("Level Success");
        }


        private IEnumerator StartNewMissionChunk()
        {
            Debug.Log($"Mission Count::{_currentMissionChunk}");
            
            if (_currentMissionChunk >= _missionChunks.Count - 1)
            {
                OnLevelSuccess();
                // Task.FromResult<object>(null);
                yield break;
            }

            yield return new WaitForEndOfFrame();

            _currentMissionChunk++;
          
            yield return new WaitForSeconds(_missionChunks[_currentMissionChunk].TimeBeforeStartChunk);
            _missionChunks[_currentMissionChunk].StartMissionChunk();
            _missionsManager.OnMissionChunkStart.Invoke(_missionChunks[_currentMissionChunk]);

            _missionsManager.OnMissionChunkSuccess += delegate(MissionChunk chunk)
            {
                _missionChunks[_currentMissionChunk].OnFinalSuccess.Action?.Invoke();
                _missionChunks[_currentMissionChunk].OnFinalSuccess.Event?.Invoke();
            };

            _missionsManager.OnMissionChunkFail += delegate(MissionChunk chunk)
            {
                _missionChunks[_currentMissionChunk].OnFinalFail.Action?.Invoke();
                _missionChunks[_currentMissionChunk].OnFinalFail.Event?.Invoke();
            };

            //    return Task.FromResult<object>(null);
        }

        private void Start()
        {
            //  _missionsManager.OnLevelStart += delegate(string s) { StartCoroutine(StartLevel()); };


            foreach (var item in _missionChunks)
            {
                item.Init();
                item.OnFinalFail.Action += OnLevelFail;
                item.OnFinalSuccess.Action += delegate { StartCoroutine(StartNewMissionChunk()); };
                item.OnFinalSuccess.Action += delegate { Debug.Log(item.ChunkMessage + " Chunks Success"); };
            }

            //   _missionsManager.OnLevelStart.Invoke(_levelDescriptionMessage);
            StartCoroutine(StartLevel());
        }

        [System.Serializable]
        public class MissionChunk
        {
            // public Action OnFinalSuccess;
            // public UnityEvent OnFinalSuccessEvent;

            // public Action OnFinalFail;
            // public UnityEvent OnFinalFailEvent;

            public ActionUnityEventPair OnFinalSuccess;
            public ActionUnityEventPair OnFinalFail;


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
                    {
                        item.OnDone += AggregateSuccessNumber;
                        item.OnDone += delegate { Debug.Log(item.Description + "aggregate Mission Done"); };
                    }

                    if (item.FailIsAggregator)
                        item.OnFail += AggregateFailureNumber;

                    if (item.SuccessIsFinal)
                    {
                        item.OnDone += delegate {  OnFinalSuccess.Action.Invoke();} ;
                        item.OnDone += item.OnChunkFinish;
                        item.OnDone += OnFinalSuccess.Event.Invoke;
                        item.OnDone += delegate { Debug.Log(item.Description + "Importan Mission Done"); };
                    }

                    if (item.LoseIsFatal)
                        item.OnFail += OnFinalFail.Action;

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


            private void AggregateSuccessNumber()
            {
                if (!AggregateSuccess) return;
                _successCounter++;

                if (_successCounter >= NumberOfSuccessToWin)
                {
                    OnFinalSuccess.Action?.Invoke();
                    OnFinalSuccess.Event?.Invoke();
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
                    OnFinalFail?.Action.Invoke();
                    OnFinalFail?.Event.Invoke();
                    foreach (var item in Missions)
                    {
                        item.OnChunkFinish();
                    }
                }
            }
        }
    }

    [System.Serializable]
    public class ActionUnityEventPair
    {
        public Action Action;
        public UnityEvent Event;
    }
}
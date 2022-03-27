using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GamePlay.Manager
{
    public interface IGamePlayUiManager
    {
        void ShowMissionFailMessage(string message);
        void ShowMissionSuccessMessage(string message);
        void ShowMissionChunkMessage(string message);
        void ShowMissionChunkSuccessMessage(string message);
        void ShowMissionChunkFailMessage(string message);

        void ShowLevelStartMessage(string message);
        void ShowLevelSuccessMessage(string message);
        void ShowLevelFailMessage(bool showPause,string message, UnityAction firstAction, UnityAction secondAction);
        void SetHealth(int value);
        void SetMaximumHealth(int value);
    };

// these messages can be show different ways so there are different functions
    public class GamePlayUiManager : MonoBehaviour, IGamePlayUiManager
    {
        [SerializeField] private TextMeshProUGUI _levelMessageText;
        [SerializeField] private PauseScreenModel _pauseScreen;
        [SerializeField] private Slider _healthSlider;
        public void ShowMissionFailMessage(string message)
        {
            _levelMessageText.text = message;
        }

        public void ShowMissionSuccessMessage(string message)
        {
            _levelMessageText.text = message;
        }

        public void ShowMissionChunkMessage(string message)
        {
            _levelMessageText.text = message;
        }

        public void ShowMissionChunkSuccessMessage(string message)
        {
            _levelMessageText.text = message;
        }

        public void ShowMissionChunkFailMessage(string message)
        {
            _levelMessageText.text = message;
        }

        public void ShowLevelStartMessage(string message)
        {
            _levelMessageText.text = message;
        }

        public void ShowLevelSuccessMessage(string message)
        {
            _levelMessageText.text = message;
        }

        public void ShowLevelFailMessage(bool showPause,string message, UnityAction firstAction, UnityAction secondAction)
        {
            _levelMessageText.text = message;
            _pauseScreen.GameObject.SetActive(showPause);
            _pauseScreen.FirstButton.onClick.RemoveAllListeners();
            _pauseScreen.SecondButton.onClick.RemoveAllListeners();

            _pauseScreen.FirstButton.onClick.AddListener(firstAction);
            _pauseScreen.SecondButton.onClick.AddListener(secondAction);
        }

        public void SetHealth(int value)
        {
            _healthSlider.value = value;
        }

        public void SetMaximumHealth(int value)
        {
            _healthSlider.maxValue = value;
            _healthSlider.value = value;
        }


        private class PauseScreenModel
        {
            public GameObject GameObject;
            public Button FirstButton;
            public Button SecondButton;
        }
    }
}
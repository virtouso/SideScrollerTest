using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        void ShowLevelFailMessage(string message);
    };

// these messages can be show different ways so there are different functions
    public class GamePlayUiManager : MonoBehaviour, IGamePlayUiManager
    {
        [SerializeField] private TextMeshProUGUI _levelMessageText;


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

        public void ShowLevelFailMessage(string message)
        {
            _levelMessageText.text = message;
        }
    }
}
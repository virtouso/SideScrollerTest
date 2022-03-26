using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Elements.Player;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour
{
    [Inject] private IPlayerCharacterController _characterController;
    [SerializeField] private Transform _startPosition;

    private void Start()
    {
        _characterController.Init(_startPosition.position);
    }
}
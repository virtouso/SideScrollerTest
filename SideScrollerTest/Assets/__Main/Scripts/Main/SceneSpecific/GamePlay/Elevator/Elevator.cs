using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IElevator
{
    public void Activate();
}

public class Elevator : MonoBehaviour, IElevator
{
    [SerializeField] private float _speed;

    [SerializeField] private Transform _platform;
    [SerializeField] private Transform[] _destinations;
    [SerializeField] private LayerMask _detectionLayer;
    [SerializeField] private Vector2 _detectionSize;
    [SerializeField] private float _distance;
    [SerializeField] private int _waitTime;
    [SerializeField] private Transform _lowerSide;
    private int _currentDestinationIndex;
    private bool _objectDetectedBelow;


    public void Activate()
    {
        _platform.gameObject.SetActive(true);
    }

    private bool DetectObjectBelow()
    {
        return Physics2D.BoxCast(_lowerSide.position, _detectionSize,
            0, Vector3.down, _distance, _detectionLayer);
        
      
        
    }

    private bool _shouldWait;

    private void Update()
    {
        _objectDetectedBelow = DetectObjectBelow();

        if (_objectDetectedBelow || _shouldWait) return;
        _platform.position =
            Vector3.MoveTowards(_platform.position,
                _destinations[_currentDestinationIndex].position, _speed);

        bool arrived =
            Vector3.SqrMagnitude(_platform.position - _destinations[_currentDestinationIndex].position) <
            _speed * _speed;

        if (arrived)
        {
            if (_currentDestinationIndex < _destinations.Length - 1)
                _currentDestinationIndex++;
            else _currentDestinationIndex = 0;
            WaitAndMove();
        }
    }

    private async Task WaitAndMove()
    {
        _shouldWait = true;
        await Task.Delay(_waitTime);
        _shouldWait = false;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        if (_objectDetectedBelow)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.blue;
        Gizmos.DrawCube(_platform.position + Vector3.down * _distance, _detectionSize);
    }
}
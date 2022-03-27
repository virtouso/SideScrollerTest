using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace GamePlay.Elements
{
    public interface IDoor
    {
        Action DoorOpened { get; set; }
    }

    public class Door : MonoBehaviour,IDoor
    {
        public Action DoorOpened { get; set; }
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            DoorOpened.Invoke();
        }
        
        
        
    }
}
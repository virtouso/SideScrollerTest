using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GamePlay.Elements
{
    public interface IKey
    {
        Action KeyGained { get; set; }

      
    }

    public class Key : MonoBehaviour, IKey
    {
        public Action KeyGained { get; set; }

     


        private void OnTriggerEnter2D(Collider2D other)
        {
            KeyGained.Invoke();
        }
    }
}
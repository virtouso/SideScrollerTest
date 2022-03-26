using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Elements
{
    public interface IKey
    {
        Action KeyGained { get; set; }

        void InteractKey();
    }

    public class Key : MonoBehaviour, IKey
    {
        public Action KeyGained { get; set; }

        public void InteractKey()
        {
            KeyGained?.Invoke();
        }
    }
}
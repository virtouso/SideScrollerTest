using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace GamePlay.Elements
{
    public interface IDoor
    {
        Action DoorOpened { get; set; }
    }

    public class Door : MonoBehaviour,IDoor
    {
        public Action DoorOpened { get; set; }
    }
}
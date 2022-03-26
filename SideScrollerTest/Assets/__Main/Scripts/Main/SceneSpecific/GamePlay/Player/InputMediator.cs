using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Elements.Player
{

    public interface IInputMediator
    {
        Action<float> HorizontalMove { get; set; }
        Action Jump { get; set; }
        Action Shoot { get; set; }
    }
    public class InputMediator :IInputMediator
    {
        public Action<float> HorizontalMove { get; set; }
        public Action Jump { get; set; }
        public Action Shoot { get; set; }
    }
}
using System.Collections;
using System.Collections.Generic;
using GamePlay.Elements;
using GamePlay.Elements.Player;
using UnityEngine;
using Zenject;

namespace GamePlay.Elements.Player
{
    public class PlayStationInputReader : BaseInputReader
    {
        [Inject] private IInputMediator _mediator;
        [Inject] private IInputValidator _inputValidator;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                _mediator.Escape.Invoke();
            
            if (GeneralReferences.Paused) return;


            float horizontalInput = Input.GetAxis("Horizontal");
            _mediator.HorizontalMove.Invoke(horizontalInput);

            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                _mediator.Jump.Invoke();

            if (Input.GetKey(KeyCode.Joystick1Button1))
                _mediator.Shoot.Invoke();


  
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using GamePlay.Elements;
using GamePlay.Elements.Player;
using UnityEngine;
using Zenject;


namespace GamePlay.Elements.Player
{


    public class WindowsInputReader : BaseInputReader
    {
        [Inject] private IInputMediator _mediator;
        [Inject] private IInputValidator _inputValidator;

        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Escape))
                _mediator.Escape.Invoke();
            
            if (GeneralReferences.Paused) return;


            float horizontalInput = Input.GetAxis("Horizontal");
            _mediator.HorizontalMove.Invoke(horizontalInput);

            if (Input.GetKeyDown(KeyCode.Space))
                _mediator.Jump.Invoke();

            if (Input.GetKey(KeyCode.RightShift))
                _mediator.Shoot.Invoke();


        
        }
    }
}
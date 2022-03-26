using System.Collections;
using System.Collections.Generic;
using GamePlay.Elements.Player;
using UnityEngine;
using Zenject;

public class WindowsInputReader : BaseInputReader
{
    [Inject] private IInputMediator _mediator;


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _mediator.HorizontalMove.Invoke(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
            _mediator.Jump.Invoke();

        if (Input.GetKey(KeyCode.RightShift))
            _mediator.Shoot.Invoke();
    }
}
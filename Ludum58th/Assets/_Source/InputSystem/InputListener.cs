using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputListener : MonoBehaviour
{
    private MainInputSystem _mainInputSystem;

    private InputAction _movement;
    private InputAction _click;

    private Invoker _invoker;

    public void Construct(Invoker invoker)
    {
        _invoker = invoker;
    }

    private void OnEnable()
    {
        _mainInputSystem = new();

        Bind();
    }

    private void Update()
    {
        Movement();
        Interact();
    }

    private void Bind()
    {
        _movement = _mainInputSystem.Player.VerticalMove;
        _movement.Enable();

        _click = _mainInputSystem.UI.Click;
        _click.performed += OnClick;
        _click.Enable();
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _invoker.InvokePhotoDisplay();
        }
        
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        _invoker.InvokeCursorTrack();
        _invoker.InvokePlaySFXClip(transform);
    }

    private void Movement()
    {
        float vertMoveF = _movement.ReadValue<float>();
        _invoker.InvokeMove(vertMoveF);
    }

    private void OnDisable()
    {
        _movement.Disable();
        _click.Disable();
    }
}

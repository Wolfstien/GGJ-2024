using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public static Action<InputAction.CallbackContext> InputTap;
    public static Action<int> ButtonTap;
    public static Action<Vector2> Joystick1, Joystick2;

    public PlayerInput playerInput;

    private void Awake() 
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void OnInputSTap(InputAction.CallbackContext value)
    {
        if (ButtonTap != null && value.performed)
        {
            ButtonTap(1);
        }
    }

    public void OnInputKTap(InputAction.CallbackContext value)
    {
        if (ButtonTap != null && value.performed)
        {
            ButtonTap(2);
        }
    }

    public void OnButtonTap(int _id)
    {
        if (ButtonTap != null)
        {
            ButtonTap(_id);
        }
    }

    public void OnJoystick1(InputAction.CallbackContext value)
    {
        if (Joystick1 != null)
        {
            Vector2 direction = value.ReadValue<Vector2>();
            Joystick1(direction);
        }
    }

    public void OnJoystick1(Vector2 _direction)
    {
        if (Joystick1 != null)
        {
            Joystick1(_direction);
        }
    }

    public void OnJoystick2(InputAction.CallbackContext value)
    {
        if (Joystick2 != null)
        {
            Vector2 direction = value.ReadValue<Vector2>();
            Joystick2(direction);
        }
    }

    public void OnJoystick2(Vector2 _direction)
    {
        if (Joystick2 != null)
        {
            Joystick2(_direction);
        }
    }
}

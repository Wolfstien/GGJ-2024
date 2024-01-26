using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public static Action<InputAction.CallbackContext> InputTap;
    public static Action<int> ButtonTap;

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

}

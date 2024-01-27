using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public static InGameUI instance;

    void Awake() 
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

    void Start()
    {
        
    }

    public void ButtonTap(int _id)
    {
        InputManager.instance.OnButtonTap(_id);
    }

    public void Joystick1Input(Vector2 _distance)
    {
        Vector2 _direction = _distance.normalized;
        InputManager.instance.OnJoystick1(_direction);
    }

    public void Joystick2Input(Vector2 _distance)
    {
        Vector2 _direction = _distance.normalized;
        InputManager.instance.OnJoystick2(_direction);
    }
}

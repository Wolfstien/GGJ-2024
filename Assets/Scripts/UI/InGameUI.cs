using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public static InGameUI instance;

    public GameObject PausePanel;

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

    void OnPause(int _value)
    {
        SoundManager.instance.PlaySFX("Pop01");
        if (PausePanel.activeSelf)
        {
            Time.timeScale = 1;
            PausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }
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

    void OnEnable() 
    {
        InputManager.Pause += OnPause;
    }

    void OnDisable() 
    {
        InputManager.Pause -= OnPause;
    }
}

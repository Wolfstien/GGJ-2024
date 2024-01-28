using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUI : MonoBehaviour
{
    public static InGameUI instance;

    public GameObject PausePanel;

    public TextMeshProUGUI RoundNo_txt;
    public Transform Player1Bottles, Player2Bottles;

    public GameObject Player1Wins, Player2Wins, VictoryPanel;

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
        GameManager.instance.RoundNo++;
        UpdateBottles();
        RoundNo_txt.SetText("Round "+GameManager.instance.RoundNo);
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

    public void UpdateBottles()
    {
        for (int i = 0; i < 3; i++)
        {
            Player1Bottles.GetChild(i).gameObject.SetActive(i<GameManager.instance.Player1Score);
        }
        for (int i = 0; i < 3; i++)
        {
            Player2Bottles.GetChild(i).gameObject.SetActive(i<GameManager.instance.Player2Score);
        }
    }

    public void ShowWinner()
    {
        Player1Wins.SetActive(false);
        Player1Wins.SetActive(false);

        if (GameManager.instance.Player1Score>=3)
        {
            Player1Wins.SetActive(true);
        }
        if (GameManager.instance.Player2Score>=3)
        {
            Player2Wins.SetActive(true);
        }

        VictoryPanel.SetActive(true);
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

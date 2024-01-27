using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempMenu : MonoBehaviour
{
    public void LoadTapGame()
    {
        SceneManager.LoadScene("TapLevel");
    }

    public void LoadJoystickGame()
    {
        SceneManager.LoadScene("JoystickLevel");

    }
}

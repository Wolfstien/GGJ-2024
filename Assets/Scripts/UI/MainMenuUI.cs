using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string levelToLoad;
    [SerializeField] private string tapLevelName;
    [SerializeField] private string joyStickLevelName;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject gameModeSelectionUI;

    void Start()
    {
        SoundManager.instance.PlayMusic("MainMenuTheme");
    }

    public void OnPlay()
    {
        //SceneManager.LoadScene(levelToLoad);
        gameModeSelectionUI.SetActive(true);
    }

    public void OnSettings()
    {
        settingsCanvas.SetActive(true);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnBack()
    {
        gameModeSelectionUI.SetActive(false);
    }

    public void OnTapMode()
    {
        SceneManager.LoadScene(tapLevelName);
    }

    public void OnJoyStickMode()
    {
        SceneManager.LoadScene(joyStickLevelName);
    }
}

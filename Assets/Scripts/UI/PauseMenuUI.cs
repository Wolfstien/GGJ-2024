using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{

    [SerializeField] private GameObject settingsCanvas;


    private string MainMenu = "MainMenu";
   
    void Start()
    {
        
    }

    public void OnResume()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnSettings()
    {
        settingsCanvas.SetActive(true);
    }

    public void OnExitToMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void OnExitToDesktop()
    {
        Application.Quit();
    }
}

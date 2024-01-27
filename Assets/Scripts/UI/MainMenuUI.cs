using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private int levelToLoad;
    [SerializeField] private GameObject settingsCanvas;


    void Start()
    {
        
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void OnSettings()
    {
        settingsCanvas.SetActive(true);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}

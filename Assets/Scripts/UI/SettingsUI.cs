using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private GameObject creditsUI;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("sfxVolume"))
            LoadVolume();
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetMusicVolume();
    }


    public void OnBack()
    {
        if (creditsUI.activeSelf)
        {
            creditsUI.SetActive(false);
        }
        else
            this.gameObject.SetActive(false);
    }

    public void OnCredits()
    {
        creditsUI.SetActive(true);
    }

    public void OnClickS1()
    {
        SoundManager.instance.PlaySFX("Pop01");
    }

    public void OnClickS2()
    {
        SoundManager.instance.PlaySFX("Pop02");
    }

    public void OnClickS3()
    {
        SoundManager.instance.PlaySFX("Pop03");
    }

}

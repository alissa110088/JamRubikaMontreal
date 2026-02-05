using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Pause : MonoBehaviour
{
    public GameObject Panel_Settings;
    public Slider Slider_Sound;
    public Slider Slider_Quality;
    
    public AudioMixer mixer;
    
    public Material M_Quality;
    public string propertyName = "Pixels_Levels";
    
    public void Resume()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("Menu_Pause");
        print("Resume");
    }

    public void Settings()
    {
        Panel_Settings.SetActive(true);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu_Main");
        print("Menu");
    }
    
    
    
    // Settings Part

    void Start()
    {
        Slider_Quality.value = M_Quality.GetFloat(propertyName);
        
        if (PlayerPrefs.HasKey("SFX_param"))
        {
            LoadVolume();
        }

        else
        {
            SetVolume();
        }
    }
    

    public void Close()
    {
        Panel_Settings.SetActive(false);
    }
    
    public void SetVolume()
    {
        float sliderValue = Slider_Sound.value;
        mixer.SetFloat("p_Master",  Mathf.Log10(sliderValue) * 20f);
        PlayerPrefs.SetFloat("p_Master", sliderValue);
    }

    public void LoadVolume()
    {
        Slider_Sound.value = PlayerPrefs.GetFloat("p_Master");
        
        SetVolume();
    }

    public void Quality()
    {
        float sliderValue = Slider_Quality.value;
        M_Quality.SetFloat(propertyName, sliderValue);
    }
}

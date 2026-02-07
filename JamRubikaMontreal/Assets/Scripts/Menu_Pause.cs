using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    
    public GameObject Panel_Settings;
    public Slider Slider_Sound;
    public Slider Slider_Quality;
    
    public AudioMixer mixer;
    
    public Material M_Quality;
    public string propertyName = "Pixels_Levels";
    
    public AudioManager _audio;
    
    public void Resume()
    {
        Time.timeScale = 1;
        SceneManager.UnloadScene("Menu_Pause");
        GameManager.Instance.isMenuOpen = false;
        _audio.Play("SFX_Button_UI");
        _audio.VolumeDown("AMB_Labubu");
    }

    public void Settings()
    {
        Panel_Settings.SetActive(true);
        _audio.Play("SFX_Button_UI");
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.UnloadScene("Menu_Pause");
        GameManager.Instance.isMenuOpen = false;
        SceneManager.LoadScene("Menu_Main", LoadSceneMode.Additive);
        _audio.Play("SFX_Button_UI");
    }
    
    
    
    // Settings Part

    void Start()
    {
        _audio = GameObject.Find("AUDIO_MANAGER").GetComponent<AudioManager>();
        _audio.Play("SFX_Button_UI");
        _audio.VolumeUp("AMB_Labubu");
        
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
        _audio.Play("SFX_Button_UI");
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

        if (sliderValue > 4000f)
        {
            StartCoroutine(GameManager.Instance.SetCrash());
        }
    }
}

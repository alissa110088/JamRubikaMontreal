using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu_Main : MonoBehaviour
{
    public AudioManager _audio;
    
    public void Start()
    {
        _audio = GameObject.Find("AUDIO_MANAGER").GetComponent<AudioManager>();
        _audio.Play("AMB_Labubu");
        _audio.VolumeUp("AMB_Labubu");
    }
    
    public void Play()
    {
        SceneManager.UnloadSceneAsync("Menu_Main");
        _audio.VolumeDown("AMB_Labubu");
        _audio.Play("SFX_Button_UI");
    }

    public void Exit()
    {
        Application.Quit();
        _audio.Play("SFX_Button_UI");
    }
}

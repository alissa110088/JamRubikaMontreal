using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Main : MonoBehaviour
{
    public AudioManager _audio;

    [SerializeField] private GameObject button;
    [SerializeField] private Image buttonImage;
    
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

   

    public void Lettre()
    {
        button.SetActive(false);
        buttonImage.gameObject.SetActive(false);
        _audio.Play("V_Start_Game");
        
        _audio.VolumeDown("AMB_Labubu");
    }
}

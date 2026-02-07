using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioManager _audio;
    
    [SerializeField] private int MaxLabubu = 30;
    [SerializeField] private UniversalRendererData urd;
    [SerializeField] private Material crash;
    [SerializeField] private GameObject pauseMenu;
    
    private int labubuCounter = 0;
    public static GameManager Instance;
    private InputSystem_Actions input;
    public bool isMenuOpen = false;
    public int LabubuCounter
    {
        get => labubuCounter;
        set
        {
            labubuCounter = value;
            if (labubuCounter >= MaxLabubu)
            {
                StartCoroutine(SetCrash());
            }
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        input = new InputSystem_Actions();
        input.Player.Enable();
        input.Player.Pause.performed += OnPause;
    }
    public void Start()
    {
        _audio = GameObject.Find("AUDIO_MANAGER").GetComponent<AudioManager>();
        SceneManager.LoadScene("Menu_Main", LoadSceneMode.Additive);
    }

    private void OnPause(InputAction.CallbackContext ctx)
    {
        if (isMenuOpen)
            return;
        isMenuOpen = true;
        Time.timeScale = 0f;
        SceneManager.LoadScene("Menu_Pause", LoadSceneMode.Additive);
    }
    

    public IEnumerator SetCrash()
    {
        var feature = urd.rendererFeatures
            .OfType<FullScreenPassRendererFeature>()
            .FirstOrDefault(f => f.name == "FullScreenPassRendererFeature");
        feature.passMaterial = crash;
        
        _audio.Stop("AMB_Labubu");
        _audio.Play_Finish("SFX_Cursed");
        
        yield return new WaitForSeconds(5f);
        Application.Quit();
        print("Crashed");
    }
}

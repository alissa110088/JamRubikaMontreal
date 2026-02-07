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

    private void Start()
    {
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
        yield return new WaitForSeconds(3f);
        Application.Quit();
    }
}

using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int MaxLabubu = 400;
    [SerializeField] private UniversalRendererData urd;
    [SerializeField] private Material crash;
    
    private int labubuCounter = 0;
    public static GameManager Instance;

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

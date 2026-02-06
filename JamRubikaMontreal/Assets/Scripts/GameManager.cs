using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int MaxLabubu = 30;
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
            Debug.Log(value);
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
        Debug.Log("should work but is not mother fucker");
        var feature = urd.rendererFeatures
            .OfType<FullScreenPassRendererFeature>()
            .FirstOrDefault(f => f.name == "FullScreenPassRendererFeature");
        feature.passMaterial = crash;
        yield return new WaitForSeconds(3f);
        Application.Quit();
    }
}

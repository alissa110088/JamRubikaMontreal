using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int MaxLabubu = 400;
    [SerializeField] private RawImage crashImage;
    
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
        crashImage.enabled = true;
        yield return new WaitForSeconds(3f);
        Application.Quit();
        
    }
}

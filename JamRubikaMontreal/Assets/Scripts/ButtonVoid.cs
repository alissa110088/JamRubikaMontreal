using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ButtonVoid : ButtonMaster
{
    public AudioManager _audio;
    
    public List<GameObject> workers = new List<GameObject>();
    private int _indexList = 0;

    private bool First_Click = true;
    protected override void OnClick()
    {
        if (First_Click)
        {
            First_Click = false;
            _audio.Play("V_Cheat");
        }
        
        if (_indexList <  workers.Count)
        {
            print(workers[_indexList].name);
            workers[_indexList].GetComponent<BoxCollider>().enabled = false;
            _indexList++;
        }
        else
        {
            Camera.main.GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine(WaitBeforeCrash());
        }
    }

    private IEnumerator WaitBeforeCrash()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(GameManager.Instance.SetCrash());
    }

    public void OnButtonClicked()
    {
        OnClick();
        _audio.Play("SFX_Button_Game");
    }

    public void Start()
    {
        _audio = GameObject.Find("AUDIO_MANAGER").GetComponent<AudioManager>();
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpeedUp : ButtonMaster
{
    public Material convoyerShader;

    void Start()
    {
        convoyerShader.SetFloat("_Speed", 1);
    }
    protected override void OnClick()
    {
        float currentSpeed = convoyerShader.GetFloat("_Speed");
        convoyerShader.SetFloat("_Speed", currentSpeed += 1);
        AffectedBySpeed.speedMultiplicator += 1;
        print(AffectedBySpeed.speedMultiplicator);
    }

    public void OnButtonClicked()
    {
        OnClick();
    }
}

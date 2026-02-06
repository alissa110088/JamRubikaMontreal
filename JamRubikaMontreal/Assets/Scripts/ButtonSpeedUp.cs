using System;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpeedUp : ButtonMaster
{
    public Material convoyerShader;

    protected override void OnClick()
    {
        float currentSpeed = convoyerShader.GetFloat("_Speed");
        convoyerShader.SetFloat("_Speed", currentSpeed += 1);
        AffectedBySpeed.speedMultiplicator += 1;
    }

    public void OnButtonClicked()
    {
        OnClick();
    }
}

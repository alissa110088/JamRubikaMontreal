using UnityEngine;

public class ButtonSpeedDown : ButtonMaster
{
    public Material convoyerShader;
    
    protected override void OnClick()
    {
        float currentSpeed = convoyerShader.GetFloat("_Speed");
        convoyerShader.SetFloat("_Speed", currentSpeed -= 1);
        AffectedBySpeed.speedMultiplicator -= 1;
    }

    public void OnButtonClicked()
    {
        OnClick();
    }
}

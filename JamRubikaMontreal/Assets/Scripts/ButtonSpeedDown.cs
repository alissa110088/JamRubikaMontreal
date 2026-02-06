using UnityEngine;

public class ButtonSpeedDown : ButtonMaster
{
    public Material convoyerShader;
    
    protected override void OnClick()
    {
        float currentSpeed = convoyerShader.GetFloat("_Speed");
        if (true)
        {
            convoyerShader.SetFloat("_Speed", currentSpeed -= 1);
            AffectedBySpeed.speedMultiplicator -= 1;
            print(AffectedBySpeed.speedMultiplicator);
        }
    }

    public void OnButtonClicked()
    {
        OnClick();
    }
}

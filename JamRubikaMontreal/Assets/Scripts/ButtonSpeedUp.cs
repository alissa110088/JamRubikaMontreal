using UnityEngine;

public class ButtonSpeedUp : ButtonMaster
{
    protected override void OnClick()
    {
        //increase shader speed and velocity speed of labubus
    }

    public void OnButtonClicked()
    {
        OnClick();
    }
}

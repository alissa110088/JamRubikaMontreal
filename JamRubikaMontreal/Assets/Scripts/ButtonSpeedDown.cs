using UnityEngine;

public class ButtonSpeedDown : ButtonMaster
{
    protected override void OnClick()
    {
        //decrease shader speed and velocity speed of labubus
    }

    public void OnButtonClicked()
    {
        OnClick();
    }
}

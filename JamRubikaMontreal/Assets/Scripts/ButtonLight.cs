using System.Collections.Generic;
using UnityEngine;

public class ButtonLight : ButtonMaster
{
    public List<GameObject> lights = new List<GameObject>();
    private bool areLightsON = true;
    protected override void OnClick()
    {
        if (areLightsON)
        {
            foreach (GameObject light in lights)
            {
                light.GetComponent<Light>().enabled = false;
            }
            areLightsON = false;
        }
        else if (!areLightsON)
        {
            foreach (GameObject light in lights)
            {
                light.GetComponent<Light>().enabled = true;
            }
            areLightsON = true;
        }
        
    }

    public void OnButtonClicked()
    {
        OnClick();
    }
}

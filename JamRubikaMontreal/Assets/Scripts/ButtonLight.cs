using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLight : ButtonMaster
{
    public List<GameObject> lights = new List<GameObject>();
    private bool areLightsON = true;
    private int pressButtonCount = 0;
    protected override void OnClick()
    {
        pressButtonCount++;
        if (pressButtonCount > 10)
        {
            foreach (GameObject light in lights)
            {
                light.GetComponent<Light>().intensity = 0;
                light.GetComponent<ParticleSystem>().Play();
            }
            
        }
        StartCoroutine(LightBurstDelay());
        if (areLightsON)
        {
            foreach (GameObject light in lights)
            {   
                if (light.GetComponent<Light>() != null)
                    light.GetComponent<Light>().enabled = false;
            }
            areLightsON = false;
        }
        else if (!areLightsON)
        {
            foreach (GameObject light in lights)
            {
                if (light.GetComponent<Light>() != null)
                    light.GetComponent<Light>().enabled = true;
            }
            areLightsON = true;
        }
        
    }

    public void OnButtonClicked()
    {
        OnClick();
    }

    IEnumerator LightBurstDelay()
    {
        yield return new WaitForSeconds(3);
        pressButtonCount = 0;
        print("LightBurst Reset");
    }
}

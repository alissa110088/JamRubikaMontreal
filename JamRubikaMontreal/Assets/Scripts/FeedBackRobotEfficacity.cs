using System;
using TMPro;
using UnityEngine;

public class FeedBackRobotEfficacity : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textEffecicacity;
    private float maxEfficacity = .5f;
    private float mminEfficaity = 5f;
    public void UpdateEfficacity(float pWaitTime)
    {
       float lPourcentage =  Math.Abs(Math.Clamp(100 - ( (100 / 4.5f) * (pWaitTime - 0.5f)),0f,100f ));

       textEffecicacity.text = lPourcentage + "% efficacity";

    } 
}

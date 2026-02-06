using System.Collections.Generic;
using UnityEngine;

public class ElectrocuteButton : AffectedBySpeed
{
    [SerializeField] private List<WorkStation> workers; 
        
    public void OnClick()
    {
        foreach (WorkStation JENAIMARE in workers)
        {
            JENAIMARE.waitTime = .5f * speedMultiplicator;
        }
    }
}

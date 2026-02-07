using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class ElectrocuteButton : AffectedBySpeed
{
    [SerializeField] private List<WorkStation> workers;

    private int countClick = 0;
    
    public void OnClick()
    {
        countClick++;

        StopAllCoroutines();
        StartCoroutine(WaitTilReset());
        foreach (WorkStation JENAIMARE in workers)
        {
            if (countClick > 5)
            {
                JENAIMARE.complete.AddExplosionForce(1000f, JENAIMARE.transform.position, 5f,3f,ForceMode.Force);
            }
            JENAIMARE.waitTime = .5f * speedMultiplicator;
            StartCoroutine(JENAIMARE.Electrocuted());
            JENAIMARE.robotText.UpdateEfficacity(.5f);
        }
    }

    private IEnumerator WaitTilReset()
    {
        yield return new WaitForSeconds(3f);
        countClick = 0;
    }
}

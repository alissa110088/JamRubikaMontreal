using System;
using System.Collections;
using UnityEngine;


public class WorkStation : AffectedBySpeed
{
    [SerializeField] private Convoyer convoyer;
    
    public FeedBackRobotEfficacity robotText;
    private labubu labubuuu;
    public float waitTime = .5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("labubu"))
        {
            //cest moooooooooooooooooche 
            labubuuu = other.gameObject.GetComponent<labubu>();
            labubuuu.isWorking = true;
            StartCoroutine(WorkingWait());
        }
    }

    private IEnumerator WorkingWait()
    {
        yield return new WaitForSeconds(waitTime * speedMultiplicator);
        labubuuu.transform.position =
            new Vector3(labubuuu.transform.position.x, labubuuu.transform.position.y + .02f, labubuuu.transform.position.z);
        labubuuu.isWorking = false;
        float lTimeToAdd = UnityEngine.Random.Range(0f, 0.8f);
        waitTime += lTimeToAdd;
        robotText.UpdateEfficacity(waitTime);
    }
}

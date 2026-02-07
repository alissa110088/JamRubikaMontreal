using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;


public class WorkStation : AffectedBySpeed
{
    [SerializeField] private Convoyer convoyer;
    [SerializeField] private GameObject electrifiedState;
    [SerializeField] private GameObject normalState;
    [SerializeField] private ParticleSystem electricalParticle;
    public Rigidbody complete;
    
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

    public IEnumerator Electrocuted()
    {
        normalState.SetActive(false);
        electrifiedState.SetActive(true);

        electrifiedState.transform.DOShakePosition(3f, 1f, 10,90, true, true, ShakeRandomnessMode.Harmonic);
        electricalParticle.Play();
        yield return new WaitForSeconds(.5f);
        normalState.SetActive(true);
        electrifiedState.SetActive(false);
    }

    
    private IEnumerator WorkingWait()
    {
        yield return new WaitForSeconds(waitTime * speedMultiplicator);
        labubuuu.transform.position =
            new Vector3(labubuuu.transform.position.x, labubuuu.transform.position.y + .02f, labubuuu.transform.position.z);
        labubuuu.isWorking = false;
        float lTimeToAdd = UnityEngine.Random.Range(0f, 0.8f);
        waitTime += lTimeToAdd / (speedMultiplicator + .1f);
        robotText.UpdateEfficacity(waitTime);
    }

    public void Kill()
    {
        normalState.SetActive(false);
        electrifiedState.SetActive(true);

        electrifiedState.transform.DOShakePosition(3f, 1f, 10,90, true, true, ShakeRandomnessMode.Harmonic);
        
        // Access the main module to change properties
        var main = electricalParticle.main;

        // Set the loop property to true
        main.loop = true;
        
        electricalParticle.Play();
    }
}

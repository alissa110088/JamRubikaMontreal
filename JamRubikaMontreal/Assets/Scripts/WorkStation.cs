using System;
using System.Collections;
using UnityEngine;

public class WorkStation : MonoBehaviour
{
    [SerializeField] private Convoyer convoyer;

    private labubu labubuuu;
    private float waitTime = .5f;
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
        yield return new WaitForSeconds(waitTime);
        Debug.Log("finished");
        labubuuu.transform.position =
            new Vector3(labubuuu.transform.position.x, labubuuu.transform.position.y + .02f, labubuuu.transform.position.z);
        labubuuu.isWorking = false;
    }
}

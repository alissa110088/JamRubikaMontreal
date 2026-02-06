using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PackLabubu : AffectedBySpeed
{
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
        DOTween.Play(transform.DOMoveY(this.transform.position.y - 6.5f, 0.3f));
        yield return new WaitForSeconds(waitTime * speedMultiplicator);
        labubuuu.PackLabubu();
        DOTween.Play(transform.DOMoveY(this.transform.position.y + 6.5f, 0.3f));

        labubuuu.transform.position =
            new Vector3(labubuuu.transform.position.x, labubuuu.transform.position.y + .02f, labubuuu.transform.position.z);
        labubuuu.isWorking = false;
        float lTimeToAdd = UnityEngine.Random.Range(0f, 0.8f);
        waitTime += lTimeToAdd;
    }
}

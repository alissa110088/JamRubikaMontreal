using System;
using UnityEngine;

public class labubu : MonoBehaviour
{
    public bool isWorking = false;

    [SerializeField] private Rigidbody rb;

    public GameObject unpackLabubu;
    public GameObject packedLabubu;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("labubu"))
        {
            rb.AddExplosionForce(300f, transform.position, 5f,3f,ForceMode.Force);
        }
    }

    public void PackLabubu()
    {
        unpackLabubu.SetActive(false);
        packedLabubu.SetActive(true);
    }
}

using System;
using UnityEngine;

public class labubu : MonoBehaviour
{
    public bool isWorking = false;

    [SerializeField] private Rigidbody rb;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("labubu"))
        {
            Debug.Log("collided");
            rb.AddExplosionForce(300f, transform.position, 5f,3f,ForceMode.Force);
        }
    }
}

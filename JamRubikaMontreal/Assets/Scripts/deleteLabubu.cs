using System;
using UnityEngine;

public class deleteLabubu : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("labubu"))
        {
            Destroy(other.gameObject);
        }
    }
}

using System;
using UnityEngine;

public class Convoyer : MonoBehaviour
{
    [SerializeField] private Vector3 direction;

    private float speed = 0.3f;
    private void Start()
    {
        direction = direction.normalized;
    }

    private void OnCollisionStay(Collision other)
    {
        
        if (other.gameObject.CompareTag("labubu"))
        {
            other.transform.position += direction * speed;
        }
    }

}
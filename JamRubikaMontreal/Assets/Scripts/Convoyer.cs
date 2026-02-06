using System;
using UnityEngine;

public class Convoyer : AffectedBySpeed
{
    [SerializeField] private Vector3 direction;

    private float speed = 0.3f;
    private void Start()
    {
        direction = direction.normalized;
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("here pettage de plond");
        if (other.gameObject.CompareTag("labubu"))
        {
            //haaaaaaaaaaa personne regarde
            labubu labubu = other.gameObject.GetComponent<labubu>();
            Debug.Log(labubu.isWorking);
            if(!labubu.isWorking)
                other.transform.position += direction * speed * speedMultiplicator;
        }
    }
}
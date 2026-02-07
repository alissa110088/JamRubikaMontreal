using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ConvoyerSpawner : AffectedBySpeed
{
    [SerializeField] private GameObject labubu;
    [SerializeField] private Transform anchorSpawn;
    
    private float spawnInterval = 5f;

    private void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(Mathf.Abs(spawnInterval / (speedMultiplicator + 1.1f)) );
        SpawnLabubu();
    }

    private void SpawnLabubu()
    {
        Instantiate(labubu, anchorSpawn.position, Quaternion.identity);
        GameManager.Instance.LabubuCounter++;
        StartCoroutine( SpawnDelay());
        
        
    }
}

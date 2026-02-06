using System;
using System.Collections;
using UnityEngine;

public class ConvoyerSpawner : AffectedBySpeed
{
    [SerializeField] private GameObject labubu;
    [SerializeField] private Transform anchorSpawn;
    
    private float spawnInterval = 4f;

    private void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(spawnInterval * speedMultiplicator);
        SpawnLabubu();
    }

    private void SpawnLabubu()
    {
        Instantiate(labubu, anchorSpawn.position, Quaternion.identity);
        GameManager.Instance.LabubuCounter++;
        StartCoroutine( SpawnDelay());
    }
}

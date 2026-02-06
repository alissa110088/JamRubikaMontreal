using System;
using System.Collections;
using UnityEngine;

public class ConvoyerSpawner : MonoBehaviour
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
        yield return new WaitForSeconds(spawnInterval);
        SpawnLabubu();
    }

    private void SpawnLabubu()
    {
        Instantiate(labubu, anchorSpawn.position, Quaternion.identity);
        StartCoroutine( SpawnDelay());
    }
}

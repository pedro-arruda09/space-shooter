using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject enemyProjectile;
    public float spawnTimer;
    public float spawnMax;
    public float spawnMin;

    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            spawnTimer = Random.Range(spawnMin, spawnMax);
        }
    }

    public void IncreaseSpawnSpeed()
    {
        spawnTimer = Random.Range(spawnMin - 1, spawnMax - 1);
    }
}

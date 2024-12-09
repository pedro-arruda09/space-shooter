using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] rows;
    public float respawnDelay = 3f;

    private Vector3[] initialPositions;

    void Start()
    {
        initialPositions = new Vector3[rows.Length];
        for (int i = 0; i < rows.Length; i++)
        {
            initialPositions[i] = rows[i].transform.position;
        }
    }

    void Update()
    {
        if (AreAllEnemiesInactive())
        {
            StartCoroutine(RespawnAllEnemies());
        }
    }

    IEnumerator RespawnAllEnemies()
    {
        yield return new WaitForSeconds(respawnDelay);

        for (int i = 0; i < rows.Length; i++)
        {
            rows[i].transform.position = initialPositions[i];
            foreach (Transform enemy in rows[i].transform)
            {
                enemy.gameObject.SetActive(true);

                ProjectileSpawner spawner = enemy.GetComponentInChildren<ProjectileSpawner>();

                if (spawner != null)
                {
                    spawner.IncreaseSpawnSpeed();
                }
                ResetEnemyPhysics(enemy.gameObject);
            }
        }
    }

    bool AreAllEnemiesInactive()
    {
        foreach (GameObject row in rows)
        {
            foreach (Transform enemy in row.transform)
            {
                if (enemy.gameObject.activeSelf)
                {
                    return false;
                }
            }
        }
        return true;
    }

    void ResetEnemyPhysics(GameObject enemy)
    {
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        ShipMovement movement = enemy.GetComponent<ShipMovement>();
        if (movement != null)
        {
            movement.enabled = true;
        }
    }
}
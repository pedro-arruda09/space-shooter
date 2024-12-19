using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    public GameObject explosionPrefab;

    public PlayerLives playerLives;

    void Start()
    {
        
    }

    void Update()
    {
        if (score >= 400 && Input.GetKeyDown(KeyCode.Space))
        {
            DestroyAllEnemies();
            score = 0;
        }
    }

    void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Instantiate(explosionPrefab, enemy.transform.position, Quaternion.identity);
            enemy.SetActive(false);
        }
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Pontuação: " + score;

        if (score >= 400)
        {
            if (playerLives == null) {
                playerLives = FindFirstObjectByType<PlayerLives>();
            }
            
            playerLives.AddLife();
            score -= 400;
        }
    }
}
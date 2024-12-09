using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    public GameObject explosionPrefab;


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
    }
}

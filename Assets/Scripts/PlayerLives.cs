using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;

    private bool isGameOver = false;

    private void Start()
    {
        UpdateLivesUI();
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = i < lives;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            HandleDamage(collision.collider.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile"))
        {
            HandleDamage(collision.gameObject);
        }
    }

    private void HandleDamage(GameObject damagingObject)
    {
        if (isGameOver) return;

        Destroy(damagingObject);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        if (isGameOver) yield break;
        isGameOver = true;

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        isGameOver = false;
        gameObject.SetActive(true);
    }
}
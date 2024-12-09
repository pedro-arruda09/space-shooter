using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 20;
    public GameObject explosionPrefab;
    private PointManager pointManager;

    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
            pointManager.UpdateScore(10);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Limite")
        {
            Destroy(gameObject);
        }
    }
}

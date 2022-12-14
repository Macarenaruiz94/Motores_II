using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private int health;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(-speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.StopSpawn();
            speed = 0f;
        }

        if (collision.gameObject.CompareTag("bullet"))
        {
            health -= 1;

            if (health == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

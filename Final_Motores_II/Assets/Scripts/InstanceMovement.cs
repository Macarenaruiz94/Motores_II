using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
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
}

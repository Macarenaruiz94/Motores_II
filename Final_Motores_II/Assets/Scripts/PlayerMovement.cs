using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    bool isGrounded;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject LaunchOffset;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AudioListener.pause = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isGrounded)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        animator.SetBool("isDmg", true);
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = LaunchOffset.transform.position;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            animator.SetTrigger("Death");
            AudioListener.pause = true;

        }
    }
}

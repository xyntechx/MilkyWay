using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject death;
    public Transform firePoint;
    public GameObject playerBullet;
    public CharacterController2D controller;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    float moveSpeed = 5f;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        controller.Move(horizontalMove, verticalMove, moveSpeed);
        controller.Rotate(horizontalMove, verticalMove);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 1)
        {
            Die();
        }
    }

    void Shoot()
    {
        Instantiate(playerBullet, firePoint.position, firePoint.rotation);
    }

    void Die()
    {
        Instantiate(death, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

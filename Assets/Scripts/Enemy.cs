using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject death;
    public GameObject enemyBullet;
    public Transform firePoint;

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float characterVelocity = 3f;
    private float x;
    private float y;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        latestDirectionChangeTime = 0f;
        calculateNewMovementVector();
    }

    void Update()
    {
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateNewMovementVector();
            Shoot();
        }

        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), 
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
    }

    void Shoot()
    {
        Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("TopBorder") || other.gameObject.CompareTag("BottomBorder"))
        {
            yInvert();
        }
        else if (other.gameObject.CompareTag("LeftBorder") || other.gameObject.CompareTag("RightBorder"))
        {
            xInvert();
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

    void Die()
    {
        Instantiate(death, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void calculateNewMovementVector()
    {
        x = Random.Range(-1.0f, 1.0f);
        y = Random.Range(-1.0f, 1.0f);
        movementDirection = new Vector2(x, y).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void yInvert()
    {
        y = y * -1;
        movementDirection = new Vector2(x, y).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void xInvert()
    {
        x = x * -1;
        movementDirection = new Vector2(x, y).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWand : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public float lifeTime = 2f;
    public LayerMask groundLayer;

    public void Initialize(Vector2 direction)
    {
        rb.velocity = direction * speed;
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            Destroy(gameObject);
            return;
        }
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(10); // Example damage value
            Destroy(gameObject); // Destroy the attack wand after hitting an enemy
        }

    }
}

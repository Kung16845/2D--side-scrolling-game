using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSlime : MonoBehaviour
{
    public float damage;
    public float lifeTime = 1f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
}

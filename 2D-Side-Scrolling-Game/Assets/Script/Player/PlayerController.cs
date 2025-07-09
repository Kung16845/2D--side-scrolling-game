using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float currentHp = 100f;
    public float maxHp = 100f;
    public Rigidbody2D rb;
    public float horizontal;
    public float damage = 10f;
    public float speed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded = true;
    public LayerMask groundLayer;
    public AttackWand attackPrefab;
    public Transform groundCheck;
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Dead();
        }
    }
    private void Update()
    {
        Move();
        Jump();
        Attack();
    }
    void Move()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal * speed, rb.velocity.y);
        rb.velocity = movement;
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump");
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Attack");
            Vector2 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (posMouse - rb.position).normalized;
            AttackWand attack = Instantiate(attackPrefab, rb.position, Quaternion.identity);
            attack.Initialize(direction);
        }
    }
    void Dead()
    {
        Debug.Log("Player died");
        currentHp = maxHp; 
        transform.position = GameManager.Instance.PlayerSpawnPoint.position; 
        rb.velocity = Vector2.zero; 
    }
}

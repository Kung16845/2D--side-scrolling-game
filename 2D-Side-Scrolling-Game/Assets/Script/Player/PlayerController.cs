using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public string itemEquipID;
    public int slotEquip;
    public LayerMask groundLayer;
    public AttackWand attackPrefab;
    public Transform groundCheck;
    public Slider sliderHealth;
    public SpriteRenderer spritePlayer;
    public void SetItemEquip(string itemID, int slotEquip = -1)
    {
        this.itemEquipID = itemID;
        this.slotEquip = slotEquip;
    }
    public void HealHealth(float amount)
    {
        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Dead();
        }
    }
    public void FlipSprite()
    {
        if (horizontal < 0) spritePlayer.flipX = true;
        else spritePlayer.flipX = false;
    }
    public void IncreaseDamage(float damage)
    {
        this.damage += damage;
    }
    public void DecreaseDamage(float damage)
    {
        this.damage -= damage;
    }
    private void Update()
    {
        Move();
        Jump();
        Attack();
        UpdateUI();
    }
    void UpdateUI()
    {
        sliderHealth.value = currentHp / maxHp;
    }
    void Move()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal * speed, rb.velocity.y);
        rb.velocity = movement;

        FlipSprite();
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

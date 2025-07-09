using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State { Idle, Patrol, Attack, Dead }
    public State currentState = State.Idle;
    public float currentHp = 100;
    public float maxHp = 100;
    public int patrolIndex = 0;
    public float idleTimer = 0f;
    public float idleDuration = 0f;
    public float chaseRange = 5f;
    public float attackRange = 1f;
    public float attackCooldown = 1.5f;
    public float lastAttackTime;
    public float speed = 2f;
    public Transform[] patrolPoints;
    public PlayerController player;
    public GameObject attackPrefab;
    public void Init()
    {
        player = GameManager.Instance.Player;
        currentHp = maxHp;
        SetRandomIdleDuration();
    }
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Dead();
        }
    }
    public virtual void Idle()
    {
        Debug.Log("Enemy is idle");
    }
    public virtual void Attack()
    {
        Debug.Log("Enemy attacks");
    }
    public virtual void Patrol()
    {
        Debug.Log("Enemy is patrolling");
    }
    public virtual void Dead()
    {
        Debug.Log("Enemy died");
        currentState = State.Dead;
        Destroy(gameObject);
    }
    public void Move(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    public void SetRandomIdleDuration()
    {
        idleDuration = Random.Range(2f, 3f);
    }
}
public enum State
{
    Idle,
    Patrol,
    Attack,
    Dead
}

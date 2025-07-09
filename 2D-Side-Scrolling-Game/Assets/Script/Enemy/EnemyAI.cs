using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State { Idle, Patrol, Attack, Dead }
    public State currentState = State.Idle;
    public int currentHp = 100;
    public int maxHp = 100;
    public float chaseRange = 5f;
    public float attackRange = 1f;
    private int patrolIndex = 0;
    public Transform[] patrolPoints;
    public float speed = 2f;
    public void TakeDamage(int damage)
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
        if (patrolPoints.Length == 0) return;
        Transform target = patrolPoints[patrolIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
        }
    }
    public void Dead()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;
            case State.Patrol:
                Patrol();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Dead:
                Dead();
                break;
        }
    }
}
public enum State
{
    Idle,
    Patrol,
    Attack,
    Dead
}

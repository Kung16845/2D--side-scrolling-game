using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyAI
{
    public int countMiniSlimeSpawn = 4;
    public EnemySlime miniSlimePrefab;
    void Start()
    {
        Init();
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
        if (currentState != State.Dead && player != null)
        {
            if (currentHp <= 0)
            {
                currentState = State.Dead;
            }
            else if (DetectPlayerByRaycast())
            {
                currentState = State.Attack;
            }
            else if (patrolPoints != null && patrolPoints.Length > 0)
            {
                currentState = State.Patrol;
            }
            else
            {
                currentState = State.Idle;
            }
        }
    }
    bool DetectPlayerByRaycast()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, chaseRange, LayerMask.GetMask("Player"));
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, chaseRange, LayerMask.GetMask("Player"));

        Debug.DrawRay(transform.position, Vector2.right * chaseRange, Color.green);
        Debug.DrawRay(transform.position, Vector2.left * chaseRange, Color.red);

        if (hitRight.collider != null || hitLeft.collider != null)
        {
            return true;
        }

        return false;
    }
    public override void Idle()
    {
        idleTimer += Time.deltaTime;
        if (idleDuration <= 0f)
        {
            idleDuration = Random.Range(2f, 3f);
        }
        if (idleTimer >= idleDuration)
        {
            idleTimer = 0f;
            idleDuration = 0f;
            currentState = State.Patrol;
        }
    }
    public override void Attack()
    {
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist <= attackRange)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                lastAttackTime = Time.time;
                Vector2 direction = (player.transform.position - transform.position).normalized;
                AttackSlime attack = Instantiate(attackPrefab, direction + (Vector2)transform.position, Quaternion.identity).GetComponent<AttackSlime>();
            }
        }
        else
        {
            Move(player.transform.position);
        }
    }
    public override void Patrol()
    {
        if (patrolPoints.Length == 0) return;
        Transform target = patrolPoints[patrolIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
            if (patrolIndex >= patrolPoints.Length - 1)
            {
                currentState = Random.Range(0, 100) < 50 ? State.Idle : State.Patrol;
                return;
            }
        }
    }
    public override void Dead()
    {
        base.Dead();
        if (miniSlimePrefab)
        {
            for (int i = 0; i < countMiniSlimeSpawn; i++)
            {
                EnemySlime miniSlime = Instantiate(miniSlimePrefab, transform.position + new Vector3(i * 0.5f, 0, 0), Quaternion.identity);
                miniSlime.patrolPoints = patrolPoints;
                miniSlime.player = player;
            }
        }
    }
}

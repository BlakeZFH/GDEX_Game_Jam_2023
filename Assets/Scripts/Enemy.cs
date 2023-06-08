using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EnemyStats
{
    public int hp = 4;
    public int damage = 1;
    public int experience_reward = 400;
    public float moveSpeed = 1f;

    public EnemyStats(EnemyStats stats)
    {
        this.hp = stats.hp;
        this.damage = stats.damage;
        this.experience_reward = stats.experience_reward;
        this.moveSpeed = stats.moveSpeed;
    }

    internal void ApplyProgress(float progress)
    {
        this.hp = (int)(hp * progress);
        this.damage = (int)(damage * progress);
    }
}

public class Enemy : MonoBehaviour, IDamagable
{
    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;

    Rigidbody2D rb;

    public EnemyStats stats;

    Vector3 knockbackVector;
    float knockbackForce;
    float knockbackTimeWeight;

    float stunned;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        //Sets target to player
        targetGameObject = target;
        targetDestination = target.transform;
    }

    internal void UpgradeStatsForProgress(float progress)
    {
        stats.ApplyProgress(progress);
    }

    private void FixedUpdate()
    {
        ProcessStun();
        Move();
    }

    private void ProcessStun()
    {
        if(stunned > 0f)
        {
            stunned -= Time.fixedDeltaTime;
        }
    }

    private void Move()
    {
        //Moves enemy toward player
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = CalculateMovementVelocity(direction) + CalculateKnockback();
    }

    private Vector3 CalculateMovementVelocity(Vector3 direction)
    {
        return direction * stats.moveSpeed * (stunned > 0f ? 0f : 1f);
    }

    private Vector3 CalculateKnockback()
    {
        if(knockbackTimeWeight > 0f)
        {
            knockbackTimeWeight -= Time.fixedDeltaTime;
        }
        return knockbackVector * knockbackForce * (knockbackTimeWeight > 0f ? 1f : 0f);
    }

    internal void SetStats(EnemyStats stats)
    {
        this.stats = new EnemyStats(stats);
    }    

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(stats.damage);
    }

    public void TakeDamage(int damage)
    {
        stats.hp -= damage;

        if(stats.hp <= 0)
        {
            targetGameObject.GetComponent<Level>().AddExperience(stats.experience_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
    }

    public void Stun(float stun)
    {
        stunned = stun;
    }

    public void Knockback(Vector3 vector, float force, float timeWeight)
    {
        knockbackVector = vector;
        knockbackForce = force;
        knockbackTimeWeight = timeWeight;
    }
}

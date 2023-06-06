using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;
    [SerializeField] float speed;

    Rigidbody2D rb;

    [SerializeField] int hp = 4;
    [SerializeField] int damage = 1;
    [SerializeField] int experience_reward = 400;

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

    private void FixedUpdate()
    {
        //Moves enemy toward player
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * speed;
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

        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
    }
}

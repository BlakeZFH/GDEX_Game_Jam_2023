using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    PlayerMovement playerMovement;
    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            IDamagable e = colliders[i].GetComponent<IDamagable>();
            if(e != null)
            {
                PostDamage(weaponStats.damage, colliders[i].transform.position);
                e.TakeDamage(weaponStats.damage);
            }
        }
    }

    public override void Attack()
    {
        StartCoroutine(AttackProcess());
    }

    IEnumerator AttackProcess()
    {
        for(int i = 0; i < weaponStats.numberOfAttacks; i++)
        {
            if (playerMovement.lastHorizontalVector < 0)
            {
                rightWhipObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, attackSize, 0f);
                ApplyDamage(colliders);
            }
            else
            {
                leftWhipObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, attackSize, 0f);
                ApplyDamage(colliders);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionOfAttack
{
    None,
    Forward,
    LeftRight,
    UpDown
}

public abstract class WeaponBase : MonoBehaviour
{
    PlayerMovement playerMovement;

    public WeaponData weaponData;

    public WeaponStats weaponStats;

    float timer;

    Character wielder;

    public Vector2 vectorOfAttack;
    [SerializeField] DirectionOfAttack attackDirection;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    public void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0f)
        {
            Attack();
            timer = weaponStats.timeToAttack;
        }
    }

    public void ApplyDamage(Collider2D[] colliders)
    {
        int damage = GetDamage();

        for (int i = 0; i < colliders.Length; i++)
        {
            IDamagable e = colliders[i].GetComponent<IDamagable>();
            if (e != null)
            {
                ApplyDamage(colliders[i].transform.position, damage, e);
            }
        }
    }

    public void ApplyDamage(Vector3 position, int damage, IDamagable e)
    {
        PostDamage(damage, position);
        e.TakeDamage(damage);
        ApplyAdditionalEffects(e, position);
    }

    private void ApplyAdditionalEffects(IDamagable e, Vector3 enemyPosition)
    {
        e.Stun(weaponStats.stun);
        e.Knockback((enemyPosition - transform.position).normalized, weaponStats.knockBack, weaponStats.knockbackTimeWeight);
    }

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;

        weaponStats = new WeaponStats(wd.stats);
    }

    public abstract void Attack();

    public int GetDamage()
    {
        int damage = (int)(weaponData.stats.damage * wielder.damageBonus);
        return damage;
    }

    public virtual void PostDamage(int damage, Vector3 targetPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), targetPosition);
    }

    public void Upgrade(UpgradeData upgradeData)
    {
        weaponStats.Sum(upgradeData.weaponUpgradeStats);
    }

    public void AddOwnerCharacter(Character character)
    {
        wielder = character;
    }

    public GameObject SpawnProjectile(GameObject prefab, Vector3 position)
    {
        GameObject projectileMove = Instantiate(prefab);
        projectileMove.transform.position = position;

        Projectile nailProjectile = projectileMove.GetComponent<Projectile>();
        nailProjectile.GetComponent<Projectile>().SetDirection(playerMovement.lastHorizontalCoupledVector, 0f);
        nailProjectile.SetStats(this);

        return projectileMove;
    }

    public void UpdateVectorOfAttack()
    {
        if(attackDirection == DirectionOfAttack.None)
        {
            vectorOfAttack = Vector2.zero;
        }

        switch (attackDirection)
        {
            case DirectionOfAttack.Forward:
                vectorOfAttack.x = playerMovement.lastHorizontalCoupledVector;
                vectorOfAttack.y = playerMovement.lastVerticalCoupledVector;
                break;
            case DirectionOfAttack.LeftRight:
                vectorOfAttack.x = playerMovement.lastHorizontalDeCoupledVector;
                vectorOfAttack.y = 0f;
                break;
            case DirectionOfAttack.UpDown:
                vectorOfAttack.x = 0f;
                vectorOfAttack.y = playerMovement.lastVerticalDeCoupledVector;
                break;
        }
        vectorOfAttack = vectorOfAttack.normalized;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailWeapon : WeaponBase
{
    PlayerMovement playerMovement;

    [SerializeField] GameObject nailPrefab;
    [SerializeField] float spread = 0.5f;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    public override void Attack()
    {
        for(int i = 0; i < weaponStats.numberOfAttacks; i++)
        {
            GameObject nail = Instantiate(nailPrefab);

            Vector3 position = transform.position;
            if(weaponStats.numberOfAttacks > 1)
            {
                position.y -= (spread * weaponStats.numberOfAttacks - 1) / 2; //calculating offset
                position.y += i * spread; //spreads projectiles
            }

            nail.transform.position = position;

            NailProjectile nailProjectile = nail.GetComponent<NailProjectile>();
            nailProjectile.GetComponent<NailProjectile>().SetDirection(playerMovement.lastHorizontalVector, 0f);
            nailProjectile.damage = weaponStats.damage;
        }
    }
}

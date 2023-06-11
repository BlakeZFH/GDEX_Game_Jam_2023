using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailWeapon : WeaponBase
{
    [SerializeField] GameObject nailPrefab;
    [SerializeField] float spread = 0.5f;

    [SerializeField] AudioSource attackSFX;

    private void Start()
    {
        attackSFX = GetComponent<AudioSource>();
    }

    public override void Attack()
    {
        UpdateVectorOfAttack();
        for(int i = 0; i < weaponStats.numberOfAttacks; i++)
        {
            Vector3 position = transform.position;
            if(weaponStats.numberOfAttacks > 1)
            {
                position.y -= (spread * weaponStats.numberOfAttacks - 1) / 2; //calculating offset
                position.y += i * spread; //spreads projectiles
            }
            SpawnProjectile(nailPrefab, position);
            attackSFX.Play();
        }
    }
}

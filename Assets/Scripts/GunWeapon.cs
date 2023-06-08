using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : WeaponBase
{
    [SerializeField] GameObject nailPrefab;

    public override void Attack()
    {
        UpdateVectorOfAttack();
        for (int i = 0; i < weaponStats.numberOfAttacks; i++)
        {
            Vector3 position = transform.position;
            SpawnProjectile(nailPrefab, position);
        }
    }
}

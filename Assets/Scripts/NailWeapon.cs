using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailWeapon : WeaponBase
{
    PlayerMovement playerMovement;

    [SerializeField] GameObject nailPrefab;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    public override void Attack()
    {
        GameObject nail = Instantiate(nailPrefab);
        nail.transform.position = transform.position;
        nail.GetComponent<NailProjectile>().SetDirection(playerMovement.lastHorizontalVector, 0f);
    }
}

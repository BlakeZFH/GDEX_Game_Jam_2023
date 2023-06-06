using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;

    PlayerMovement playerMovement;

    [SerializeField] GameObject nailPrefab;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        if(timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnNail();
    }

    private void SpawnNail()
    {
        GameObject nail = Instantiate(nailPrefab);
        nail.transform.position = transform.position;
        nail.GetComponent<NailProjectile>().SetDirection(playerMovement.lastHorizontalVector, 0f);
    }
}

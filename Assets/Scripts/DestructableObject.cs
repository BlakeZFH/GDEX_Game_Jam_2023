using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, IDamagable
{
    public void Knockback(Vector3 vector, float force, float timeWeight)
    {

    }

    public void Stun(float stun)
    {

    }

    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
        GetComponent<DropOnDestroy>().CheckDrop();
    }
}

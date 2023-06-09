using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    WeaponBase weapon;

    public float attackArea = 0.7f;
    Vector3 direction;
    float speed;
    int damage = 1;
    int numOfHits = 1;

    List<IDamagable> enemiesHit;

    float ttl = 6f;

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    void Update()
    {
        Move();

        //Call every 6 frames instead of every frame to optimize performance
        if (Time.frameCount % 6 == 0)
        {
            HitDetection();
        }

        TimerToLive();
    }

    private void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void HitDetection()
    {
        //Create circle around object and create an array of all other objects that it collides with
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, attackArea);

        //Iterate through collision, destroy object and deal damage if collision object has enemy script
        foreach (Collider2D c in hit)
        {
            if (numOfHits > 0)
            {
                IDamagable enemy = c.GetComponent<IDamagable>();
                if (enemy != null)
                {
                    if (CheckRepeatHit(enemy) == false)
                    {
                        weapon.ApplyDamage(c.transform.position, damage, enemy);
                        enemiesHit.Add(enemy);
                        numOfHits -= 1;
                    }
                }
            }
            else
            { break; }
        }
            if (numOfHits <= 0)
            {
                Destroy(gameObject);
            }
    }

    private bool CheckRepeatHit(IDamagable enemy)
    {
        if (enemiesHit == null) { enemiesHit = new List<IDamagable>(); }

        return enemiesHit.Contains(enemy);
    }

    private void TimerToLive()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0f)
        {
            Destroy(gameObject);
        }
    }

    public void PostDamage(int damage, Vector3 worldPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), worldPosition);
    }

    public void SetStats(WeaponBase weaponBase)
    {
        weapon = weaponBase;
        speed = weaponBase.weaponStats.projectileSpeed;
        damage = weaponBase.GetDamage();
        numOfHits = weaponBase.weaponStats.numberOfHits;
    }

    private void OnEnable()
    {
        ttl = 6f;
    }
}

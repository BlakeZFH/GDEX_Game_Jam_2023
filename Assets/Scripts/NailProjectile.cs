using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailProjectile : MonoBehaviour
{
    public float attackArea = 0.7f;
    Vector3 direction;
    [SerializeField] float speed;
    public int damage = 1;
    public int numOfHits = 1;

    List<IDamagable> enemiesHit;

    float ttl = 6f;

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.z = scale.z * -1;
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
                        PostDamage(damage, transform.position);
                        enemiesHit.Add(enemy);
                        enemy.TakeDamage(damage);
                        numOfHits -= 1;
                    }
                }
            }
            else
            { break; }

            if (numOfHits <= 0)
            {
                Destroy(gameObject);
            }
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
}

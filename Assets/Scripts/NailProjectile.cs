using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailProjectile : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    public int damage = 1;

    bool hitDetected = false;

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
        transform.position += direction * speed * Time.deltaTime;

        //Call every 6 frames instead of every frame to optimize performance
        if (Time.frameCount % 6 == 0)
        {
            //Create circle around object and create an array of all other objects that it collides with
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.7f);

            //Iterate through collision, destroy object and deal damage if collision object has enemy script
            foreach (Collider2D c in hit)
            {
                IDamagable enemy = c.GetComponent<IDamagable>();
                if (enemy != null)
                {
                    PostDamage(damage, transform.position);
                    enemy.TakeDamage(damage);
                    hitDetected = true;
                    break;
                }
            }
            if (hitDetected)
            {
                Destroy(gameObject);
            }
        }

        ttl -= Time.deltaTime;
        if(ttl < 0f)
        {
            Destroy(gameObject);
        }
    }

    public void PostDamage(int damage, Vector3 worldPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), worldPosition);
    }
}

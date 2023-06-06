using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour
{
    [SerializeField] float timeToLeave = 0.5f;
    float ttl = 0.5f;

    private void OnEnable()
    {
        ttl = timeToLeave;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if(ttl < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}

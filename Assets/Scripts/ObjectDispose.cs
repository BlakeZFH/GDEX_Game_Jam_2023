using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDispose : MonoBehaviour
{
    Transform playerTransform;
    float maxDistance = 25f;

    private void Start()
    {
        playerTransform = GameManager.instance.playerTransform;
    }

    private void Update()
    {
        //Destroys objects upon reaching max distance from player
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if(distance > maxDistance)
        {
            Destroy(gameObject);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePosition;
    [SerializeField] List<SpawnObject> spawnObjects;
    void Start()
    {
        GetComponentInParent<WorldScrolling>().Add(gameObject, tilePosition);

        transform.position = new Vector3(-100, -100, 0);
    }

    public void Spawn()
    {
        //Spawns X by X area of tiles

        for(int i = 0; i < spawnObjects.Count; i++)
        {
            spawnObjects[i].Spawn();
        }
    }
}

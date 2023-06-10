using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityTools
{
    public static Vector3 GenerateRandomPositionSquarePattern(Vector2 spawnArea)
    {
        //Creates a square-shaped spawnable area just outside of player's FOV
        //Prevents enemies from spawning too far away or within player's FOV
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }

        position.z = 0;

        return position;
    }
}

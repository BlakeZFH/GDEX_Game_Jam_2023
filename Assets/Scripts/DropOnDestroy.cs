using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject dropItemPrefab;
    [SerializeField] [Range(0f, 1f)] float chance = 1f;

    bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void CheckDrop()
    {
        //Does not drop object if parent is destoryed via quitting
        if (isQuitting) { return; }

        //Drops object on parent destroy
        if(Random.value < chance)
        {
            Transform t = Instantiate(dropItemPrefab).transform;
            t.position = transform.position;
        }
    }
}

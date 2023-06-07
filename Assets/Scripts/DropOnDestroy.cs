using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] List<GameObject> dropItemPrefab;
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

        if(dropItemPrefab.Count <= 0)
        {
            Debug.LogWarning("List of drop items is empty");
        }

        //Drops object on parent destroy
        if(Random.value < chance)
        {
            GameObject toDrop = dropItemPrefab[Random.Range(0, dropItemPrefab.Count)];

            if(toDrop == null)
            {
                Debug.LogWarning("DropOnDestroy, reference to dropped item is null -- check the prefab object which drops items on destroy");
                return;
            }

            SpawnManager.instance.SpawnObject(transform.position, toDrop);
        }
    }
}

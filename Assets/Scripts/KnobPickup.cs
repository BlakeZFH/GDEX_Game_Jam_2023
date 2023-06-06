using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobPickup : MonoBehaviour, IPickupObject
{
    [SerializeField] int count;

    public void OnPickUp(Character character)
    {
        character.doorknobs.Add(count);
    }
}

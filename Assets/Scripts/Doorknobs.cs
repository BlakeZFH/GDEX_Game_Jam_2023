using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorknobs : MonoBehaviour
{
    public int knobsAcquired;
    [SerializeField] TMPro.TextMeshProUGUI doorknobsCountText;

    public void Add(int count)
    {
        knobsAcquired += count;
        doorknobsCountText.text = "Doorknobs: " + knobsAcquired.ToString();
    }
}

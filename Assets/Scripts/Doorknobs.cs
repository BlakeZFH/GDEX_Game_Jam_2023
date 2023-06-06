using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorknobs : MonoBehaviour
{
    [SerializeField] DataContainer data;
    [SerializeField] TMPro.TextMeshProUGUI doorknobsCountText;

    public void Add(int count)
    {
        data.doorknobs += count;
        doorknobsCountText.text = "Doorknobs: " + data.doorknobs.ToString();
    }
}

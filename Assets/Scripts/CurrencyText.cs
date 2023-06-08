using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyText : MonoBehaviour
{
    [SerializeField] DataContainer dataContainer;
    TMPro.TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = "Doorknobs: " + dataContainer.doorknobs.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] PlayerPersistantUpgrades upgrade;

    [SerializeField] TextMeshProUGUI upgradeName;
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI price;

    [SerializeField] DataContainer dataContainer;

    private void Start()
    {
        UpdateElement();
    }

    public void Upgrade()
    {
        PlayerUpgrades playerUpgrades = dataContainer.upgrades[(int)upgrade];

        if (playerUpgrades.level >= playerUpgrades.max_level) { return; }
        if(dataContainer.doorknobs >= playerUpgrades.costToUpgrade)
        {
            dataContainer.doorknobs -= playerUpgrades.costToUpgrade;
            playerUpgrades.level += 1;
            UpdateElement();
        }
    }
    void UpdateElement()
    {
        PlayerUpgrades playerUpgrade = dataContainer.upgrades[(int)upgrade];

        upgradeName.text = upgrade.ToString();
        level.text = playerUpgrade.level.ToString();
        price.text = playerUpgrade.costToUpgrade.ToString();
    }
}

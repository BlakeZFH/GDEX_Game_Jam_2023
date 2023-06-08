using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PlayerPersistantUpgrades
{
    HP,
    Damage
}

[Serializable]
public class PlayerUpgrades
{
    public PlayerPersistantUpgrades persistantUpgrades;
    public int level = 0;
    public int max_level = 10;
    public int costToUpgrade = 100;
}

[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
    public int doorknobs;

    public List<bool> stageCompletion;

    public List<PlayerUpgrades> upgrades;

    public void StageComplete(int i)
    {
        stageCompletion[i] = true;
    }

    public int GetUpgradeLevel(PlayerPersistantUpgrades persistantUpgrade)
    {
        return upgrades[(int)persistantUpgrade].level;
    }
}

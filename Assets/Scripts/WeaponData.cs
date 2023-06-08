using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WeaponStats
{
    public int damage;
    public float timeToAttack;
    public int numberOfAttacks;
    public float knockBack;
    public int numberOfHits;
    public float projectileSpeed;
    public float stun;
    public float knockbackTimeWeight;

    public WeaponStats(WeaponStats stats)
    {
        this.damage = stats.damage;
        this.timeToAttack = stats.timeToAttack;
        this.numberOfAttacks = stats.numberOfAttacks;
        this.knockBack = stats.knockBack;
        this.numberOfHits = stats.numberOfHits;
        this.projectileSpeed = stats.projectileSpeed;
        this.stun = stats.stun;
        this.knockbackTimeWeight = stats.knockbackTimeWeight;
    }

    internal void Sum(WeaponStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
        this.numberOfAttacks += weaponUpgradeStats.numberOfAttacks;
        this.knockBack += weaponUpgradeStats.knockBack;
        this.numberOfHits += weaponUpgradeStats.numberOfHits;
        this.projectileSpeed += weaponUpgradeStats.projectileSpeed;
        this.stun += weaponUpgradeStats.stun;
        this.knockbackTimeWeight += weaponUpgradeStats.knockbackTimeWeight;
    }
}

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpgradeData> upgrades;
}

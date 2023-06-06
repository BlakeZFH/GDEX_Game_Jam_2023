using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    [SerializeField] StatusBar hpBar;

    public int armor = 0;

    [HideInInspector] public Level level;
    [HideInInspector] public Doorknobs doorknobs;

    private bool isDead;

    private void Awake()
    {
        level = GetComponent<Level>();
        doorknobs = GetComponent<Doorknobs>();
    }

    private void Start()
    {
        //Sets healthbar fill at start of level
        hpBar.SetState(currentHp, maxHp);
    }

    public void TakeDamage(int damage)
    {
        if(isDead)
        {
            return;
        }

        ApplyArmor(ref damage);

        currentHp -= damage;

        if(currentHp <= 0)
        {
            GetComponent<GameOver>().PlayerGameOver();
            isDead = true;
        }
        hpBar.SetState(currentHp, maxHp);
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        //Prevents healing player if damage does not exceed armor
        if (damage < 0) { damage = 0; }
    }

    public void Heal(int amount)
    {
        if (currentHp <= 0) { return; }

        currentHp += amount;
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
    }
}

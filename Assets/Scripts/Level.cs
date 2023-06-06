using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar experienceBar;

    //Defines xp needed to level up
    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }

    }

    private void Start()
    {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }

    public void AddExperience(int amount)
    {
        //Increases xp based on pickup or kill
        experience += amount;
        CheckLevelUp();
        //Increments xp bar
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void CheckLevelUp()
    {
        //Increases level by 1 if xp threshold is crossed
        if(experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
            experienceBar.SetLevelText(level);
        }
    }
}

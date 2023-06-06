using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;

    StageTime stageTime;
    PauseManager pauseManager;

    [SerializeField] GameObject levelCompleteMenu;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
        pauseManager = FindAnyObjectByType<PauseManager>();
    }

    public void Update()
    {
        if(stageTime.time > timeToCompleteLevel)
        {
            pauseManager.PauseGame();
            levelCompleteMenu.SetActive(true);
        }
    }
}

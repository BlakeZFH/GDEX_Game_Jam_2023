using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] EnemiesManager enemiesManager;

    StageTime stageTime;
    int eventIndexer;
    PlayerWinManager playerWinManager;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }

    private void Start()
    {
        playerWinManager = FindAnyObjectByType<PlayerWinManager>();
    }

    private void Update()
    {
        if (eventIndexer >= stageData.stageEvents.Count) { return; }

        if(stageTime.time > stageData.stageEvents[eventIndexer].time)
        {
            switch(stageData.stageEvents[eventIndexer].eventType)
            {
                case StageEventType.spawnEnemy:
                    for (int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
                    {
                        SpawnEnemy();
                    }
                    break;
                case StageEventType.spawnObject:
                    for(int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
                    {
                        SpawnObject();
                    }
                    break;
                case StageEventType.winStage:
                    WinStage();
                    break;
            }
            eventIndexer += 1;
        }
    }

    private void WinStage()
    {
        playerWinManager.Win();
    }

    private void SpawnObject()
    {
        Vector3 positionToSpawn = GameManager.instance.playerTransform.position;
        positionToSpawn += UtilityTools.GenerateRandomPositionSquarePattern(new Vector2(5f, 5f));

        SpawnManager.instance.SpawnObject(
             positionToSpawn,
             stageData.stageEvents[eventIndexer].objectToSpawn
             );
    }    

    private void SpawnEnemy()
    {
        enemiesManager.SpawnEnemy(stageData.stageEvents[eventIndexer].enemyToSpawn);
    }

}

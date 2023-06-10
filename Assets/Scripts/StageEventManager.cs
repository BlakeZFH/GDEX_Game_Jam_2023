using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    EnemiesManager enemiesManager;

    StageTime stageTime;
    int eventIndexer;
    PlayerWinManager playerWin;

    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
    }

    private void Start()
    {
        playerWin = FindAnyObjectByType<PlayerWinManager>();
        enemiesManager = FindAnyObjectByType<EnemiesManager>();
    }

    private void Update()
    {
        if (eventIndexer >= stageData.stageEvents.Count) { return; }

        if(stageTime.time > stageData.stageEvents[eventIndexer].time)
        {
            switch(stageData.stageEvents[eventIndexer].eventType)
            {
                case StageEventType.spawnEnemy:
                    SpawnEnemy(false);
                    break;
                case StageEventType.spawnObject:
                        SpawnObject();
                    break;
                case StageEventType.winStage:
                    WinStage();
                    break;
                case StageEventType.spawnEnemyBoss:
                    SpawnEnemyBoss();
                    break;
            }
            eventIndexer += 1;
        }
    }

    private void SpawnEnemyBoss()
    {
        SpawnEnemy(true);
    }

    private void WinStage()
    {
        playerWin.Win();
    }

    private void SpawnObject()
    {
        for (int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
        {
            Vector3 positionToSpawn = GameManager.instance.playerTransform.position;
            positionToSpawn += UtilityTools.GenerateRandomPositionSquarePattern(new Vector2(5f, 5f));

            SpawnManager.instance.SpawnObject(
                 positionToSpawn,
                 stageData.stageEvents[eventIndexer].objectToSpawn
                 );
        }
    }    

    private void SpawnEnemy(bool bossEnemy)
    {
        StageEvent currentEvent = stageData.stageEvents[eventIndexer];
        enemiesManager.AddGroupToSpawn(currentEvent.enemyToSpawn, currentEvent.count, bossEnemy);

        if(currentEvent.isRepeatedEvent == true)
        {
            enemiesManager.AddRepeatedSpawn(currentEvent, bossEnemy);
        }
    }
}

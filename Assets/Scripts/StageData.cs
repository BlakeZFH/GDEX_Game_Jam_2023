using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum StageEventType
{
    spawnEnemy,
    spawnObject,
    winStage,
    spawnEnemyBoss
}

[Serializable]

public class StageEvent
{
    public StageEventType eventType;

    public float time;
    public string message;

    public EnemyData enemyToSpawn;
    public GameObject objectToSpawn;
    public int count;

    public bool isRepeatedEvent;
    public float repeatEverySeconds;
    public int repeatCount;
}

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    public List<StageEvent> stageEvents;
}

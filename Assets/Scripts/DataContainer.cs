using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataContainer : ScriptableObject
{
    public int doorknobs;

    public List<bool> stageCompletion;

    public void StageComplete(int i)
    {
        stageCompletion[i] = true;
    }
}

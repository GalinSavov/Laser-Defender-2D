using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveConfigSO waveConfig= null;

    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < waveConfig.GetEnemyCount(); i++)
        {
            Instantiate(waveConfig.GetEnemyAtIndex(i),waveConfig.GetStartingWaypoint().position,Quaternion.identity,transform);
        }
    }

    public WaveConfigSO GetCurrentWaveConfig()
    {
        return waveConfig;
    }
}

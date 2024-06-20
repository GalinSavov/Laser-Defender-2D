using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSO> waveConfigs= null;
    [SerializeField] private float timeBetweenWaves = 3f;
    private WaveConfigSO currentWaveConfig;
    

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    private IEnumerator SpawnEnemyWaves()
    {
        for (int i = 0; i < waveConfigs.Count; i++)
        {
            currentWaveConfig = waveConfigs[i];
            for (int j = 0; j < currentWaveConfig.GetEnemyCount(); j++)
            {
                yield return new WaitForSeconds(currentWaveConfig.GetRandomSpawnTime());
                Instantiate(currentWaveConfig.GetEnemyAtIndex(j), currentWaveConfig.GetStartingWaypoint().position, Quaternion.identity, transform);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }

    }

    public WaveConfigSO GetCurrentWaveConfig()
    {
        return currentWaveConfig;
    }
}

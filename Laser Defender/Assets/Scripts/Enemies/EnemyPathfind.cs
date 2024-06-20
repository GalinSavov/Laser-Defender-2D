using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfind : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private WaveConfigSO waveConfig;

    private List<Transform> waypoints = new List<Transform>();
    private int index = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWaveConfig();
        waypoints = waveConfig.GetWaypoints();
    }

    
    void Update()
    {
        NavigatePath();
    }

    private void NavigatePath()
    {
        if(index < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[index].position;
            float moveSpeed = waveConfig.GetMoveSpeed() * Time.deltaTime;

            //check if lerp can also work
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);

            if (transform.position == targetPosition)
                index++;
        }
        else 
            Destroy(gameObject);

    }
}

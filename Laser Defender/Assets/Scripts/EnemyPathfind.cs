using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfind : MonoBehaviour
{
    [SerializeField] private WaveConfigSO waveConfigSO = null;
    private List<Transform> waypoints = new List<Transform>();
    private int index = 0;
    
    void Start()
    {
        waypoints = waveConfigSO.GetWaypoints();
        transform.position = waypoints[index].position;
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
            float moveSpeed = waveConfigSO.GetMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);

            if (transform.position == targetPosition)
                index++;
        }
        else 
            Destroy(gameObject);

    }
}

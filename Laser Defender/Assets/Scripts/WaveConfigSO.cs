using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Config", menuName = "Create a new wave")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private Transform pathPrefab = null;
    [SerializeField] private float moveSpeed = 5f;

    public float GetMoveSpeed() { return moveSpeed; }

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform waypoint in pathPrefab)
        {
            waypoints.Add(waypoint);
        }
        return waypoints;
    }
}

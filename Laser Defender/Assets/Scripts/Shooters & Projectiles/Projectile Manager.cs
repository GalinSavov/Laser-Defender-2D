using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    private ObjectPool objectPool;
    private void Awake()
    {
        objectPool = FindObjectOfType<ObjectPool>();
        Shooter.OnShoot += HandleShooting;
    }
    private void HandleShooting(GameObject projectile,ProjectileType type)
    {
        StartCoroutine(objectPool.ReturnToPool(projectile, type, 1.5f));
    }
    private void OnDisable()
    {
        Shooter.OnShoot -= HandleShooting;
    }
}

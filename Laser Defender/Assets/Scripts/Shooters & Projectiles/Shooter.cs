using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] protected float projectileSpeed = 10f;
    [SerializeField] protected float baseFiringRate = 1f;
    [SerializeField] protected Transform projectileSpawnPoint = null;

    protected ObjectPool objectPool;
    protected Coroutine firingCoroutine;
    protected GameObject projectile;
    public static Action<GameObject,ProjectileType> OnShoot;
    protected void Awake()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }
    protected IEnumerator Shoot(float fireRate,ProjectileType type)
    {
        while (true)
        {
            projectile = objectPool.GetObject(type);
            projectile.transform.position = projectileSpawnPoint.position;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            AudioManager.instance.PlayShootingClip();
            OnShoot?.Invoke(projectile,type);
            yield return new WaitForSeconds(fireRate);
        }
    }
}

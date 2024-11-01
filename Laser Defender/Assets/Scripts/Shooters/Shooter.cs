using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour,IShootable
{
    [Header("General")]
    [SerializeField] protected GameObject projectilePrefab = null;
    [SerializeField] protected float projectileSpeed = 10f;
    [SerializeField] protected float projectileLifetime = 3f;
    [SerializeField] protected float baseFiringRate = 1f;
    protected Coroutine firingCoroutine;
    protected AudioPlayer audioPlayer;
    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    public abstract IEnumerator Shoot();
}

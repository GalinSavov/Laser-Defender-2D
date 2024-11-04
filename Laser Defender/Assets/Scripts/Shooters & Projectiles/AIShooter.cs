using System;
using System.Collections;
using UnityEngine;

public class AIShooter : Shooter
{
    [Header("AI")]
    [SerializeField] private float minFiringRate = 0.5f;
    [SerializeField] private float maxFiringRate = 2f;
    private void Start()
    {
       firingCoroutine = StartCoroutine(Shoot(UnityEngine.Random.Range(minFiringRate, maxFiringRate) + baseFiringRate,ProjectileType.Enemy));
    }
}   
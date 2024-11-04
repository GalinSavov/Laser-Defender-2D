using System;
using System.Collections;
using UnityEngine;

public class PlayerShooter : Shooter
{
    [HideInInspector] public bool IsFiring { get; set; }
    private void Update()
    {
        if(IsFiring && firingCoroutine == null)
        firingCoroutine = StartCoroutine(Shoot(baseFiringRate,ProjectileType.Player));
        else if(!IsFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }
}
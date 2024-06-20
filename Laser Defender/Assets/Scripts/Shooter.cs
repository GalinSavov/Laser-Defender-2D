using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 3f;
    [SerializeField] private float baseFiringRate = 1f;

    [Header("AI")]
    [SerializeField] private float minFiringRate = 0.5f;
    [SerializeField] private float maxFiringRate = 2f;
    [SerializeField] private bool useAI = false;

    private Coroutine firingCoroutine;
    [HideInInspector] public bool PlayerIsFiring {  get;  set; }


    private void Start()
    {
        if(useAI)
            PlayerIsFiring = true;
    }
    private void Update()
    {
        
        if(PlayerIsFiring && firingCoroutine == null)
            firingCoroutine = StartCoroutine(FireContinuosly());

        else if(!PlayerIsFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }
    private IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab,transform.position,Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(projectile, projectileLifetime);
            yield return new WaitForSeconds(Random.Range(minFiringRate,maxFiringRate) + baseFiringRate);
        }
       
    }
}

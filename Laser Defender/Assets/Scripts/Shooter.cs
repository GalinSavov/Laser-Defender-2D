using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 3f;
    [SerializeField] private float firingRate = 1f;

    private Coroutine firingCoroutine;

    public bool isFiring {  get;  set; }

    private void Start()
    {
        
    }
    private void Update()
    {
        if(isFiring && firingCoroutine == null)
            firingCoroutine = StartCoroutine(FireContinuosly());

        else if(!isFiring && firingCoroutine != null)
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
                rb.velocity = Vector2.up * projectileSpeed;
            }
            Destroy(projectile, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
       
    }
}

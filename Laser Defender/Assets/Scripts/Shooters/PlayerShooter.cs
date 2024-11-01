using System.Collections;
using UnityEngine;

public class PlayerShooter : Shooter
{
    [HideInInspector] public bool IsFiring { get; set; }
    private void Update()
    {
        if(IsFiring && firingCoroutine == null)
        firingCoroutine = StartCoroutine(Shoot());
        else if(!IsFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }
    public override IEnumerator Shoot()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            AudioManager.instance.PlayShootingClip();
            Destroy(projectile, projectileLifetime);
            yield return new WaitForSeconds(baseFiringRate);
        }
    }
}
using System.Collections;
using UnityEngine;

public class AIShooter : Shooter
{
    [Header("AI")]
    [SerializeField] private float minFiringRate = 0.5f;
    [SerializeField] private float maxFiringRate = 2f;
    private void Start()
    {
        firingCoroutine = StartCoroutine(Shoot());
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
            audioPlayer.PlayShootingClip();
            Destroy(projectile, projectileLifetime);
            yield return new WaitForSeconds(Random.Range(minFiringRate, maxFiringRate) + baseFiringRate);
        }
    }
    private void OnDestroy()
    {
        StopCoroutine(firingCoroutine);
    }
}   
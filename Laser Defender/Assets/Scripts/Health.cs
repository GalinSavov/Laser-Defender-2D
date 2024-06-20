using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth = 100f;
    [SerializeField] private ParticleSystem explosionParticles = null;
    [SerializeField] private CameraShake cameraShake = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            damageDealer.Destroy();
            PlayExplosion();
            ShakeCamera();
            DealDamage(damageDealer.GetDamage());
        }
    }

    private void DealDamage(int amount)
    {
        
        startingHealth -= amount;

        if (startingHealth <= 0)
            Destroy(gameObject);

        
    }
    private void PlayExplosion()
    {
       if (explosionParticles != null)
        {
            ParticleSystem effect = Instantiate(explosionParticles, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject,effect.main.duration);
        }
    }
    private void ShakeCamera()
    {
        if (cameraShake != null)
        {
            cameraShake.ShakeCamera();

        }
    }   
    
}

using System;
using UnityEngine;

public class ExplosionParticles : Particles
{
    private void OnEnable()
    {
        Health.OnTargetDamaged += HandleDamage;
    }
    private void HandleDamage(Transform damaged)
    {
        if (particles != null)
        {
            ParticleSystem effect = Instantiate(particles, damaged.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }
    }
    private void OnDisable()
    {
        Health.OnTargetDamaged -= HandleDamage;
    }
    private void HandleDamage()
    {
        PlayParticles();
    }
    protected override void PlayParticles()
    {
        
    }
}
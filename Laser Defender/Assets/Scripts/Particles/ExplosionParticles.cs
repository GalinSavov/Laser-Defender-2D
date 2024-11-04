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
       PlayParticles(damaged);
    }
    private void OnDisable()
    {
        Health.OnTargetDamaged -= HandleDamage;
    }
    protected override void PlayParticles(Transform transform)
    {
        if (particles != null)
        {
            ParticleSystem effect = Instantiate(particles, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }
    }
}
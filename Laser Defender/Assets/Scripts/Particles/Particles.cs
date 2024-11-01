using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Particles : MonoBehaviour
{
    [SerializeField] protected ParticleSystem particles = null;
    protected abstract void PlayParticles();
}

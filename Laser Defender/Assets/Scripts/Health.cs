using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth = 100f;
    [SerializeField] private ParticleSystem explosionParticles = null;
    [SerializeField] private CameraShake cameraShake = null;

    public float CurrentHealth { get; private set; }
    private AudioPlayer audioPlayer;
    private ScoreKeeper scoreKeeper;

   
    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        CurrentHealth = startingHealth;
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            damageDealer.Destroy();
            PlayExplosion();
            audioPlayer.PlayDamageClip();
            ShakeCamera();
            DealDamage(damageDealer.GetDamage());
        }
    }

    private void DealDamage(int amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            if(gameObject.CompareTag("Enemy"))
            scoreKeeper.IncreaseScore(50);

            Destroy(gameObject);
        }
    }
    private void PlayExplosion()
    {
        if (explosionParticles != null)
        {
            ParticleSystem effect = Instantiate(explosionParticles, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
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

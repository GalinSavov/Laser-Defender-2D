using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth = 100f;
    public float CurrentHealth { get; private set; }
    public static Action OnPlayerDeath;
    public static Action<Transform> OnTargetDamaged;
    public static Action OnPlayerDamaged;
    private void Awake()
    {
        CurrentHealth = startingHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer.tag == "Enemy")
        {
            OnPlayerDamaged?.Invoke();
        }
        damageDealer.Destroy();
        OnTargetDamaged?.Invoke(this.transform);
        AudioManager.instance.PlayDamageClip();
        DealDamage(damageDealer.GetDamage());
    }
    private void DealDamage(int amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            if (gameObject.CompareTag("Enemy"))
                ScoreManager.instance.IncreaseScore(50);

            else if (gameObject.CompareTag("Player"))
                OnPlayerDeath?.Invoke();

            Destroy(gameObject);
        }
    }
}

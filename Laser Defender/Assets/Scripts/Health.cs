using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth = 100f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            damageDealer.Destroy();
            DealDamage(damageDealer.GetDamage());
        }
    }

    private void DealDamage(int amount)
    {
        startingHealth -= amount;

        if (startingHealth <= 0)
            Destroy(gameObject);

        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 20;
    public int GetDamage()
    {
        return damage;
    }
    //when a projectile(damage dealer) collides with something, deactivate it
    public void Destroy()
    {
        this.gameObject.SetActive(false);
    }
}

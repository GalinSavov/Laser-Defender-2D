using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float projectileSpeed = 5f;
    void Start()
    {
        rb.velocity = new Vector2(0,projectileSpeed * GetComponentInParent<Transform>().localScale.y);
    }

    
}

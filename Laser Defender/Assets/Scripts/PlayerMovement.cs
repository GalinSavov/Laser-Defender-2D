using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        
        [SerializeField] private float moveSpeed = 5f;

        [SerializeField] private float paddingLeft = 1f;
        [SerializeField] private float paddingRight = 1f;
        [SerializeField] private float paddingTop = 1f;
        [SerializeField] private float paddingBottom = 1f;

        
        [SerializeField] private Transform projectileSpawnPoint = null;

        [SerializeField] private Shooter shooter = null;

        private Vector2 moveInput;

        private Vector3 minBounds;
        private Vector3 maxBounds;

        
        void Start()
        {
            InitBounds();
        }
        private void Update()
        {
            Move();
        }

        /// <summary>
        /// Move the player based on input
        /// Clamp the x and y values so they stay between bounds
        /// </summary>
        private void Move()
        {
            Vector3 delta = moveSpeed * moveInput * Time.deltaTime;

            Vector2 newPos = new Vector2();
            newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
            newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

            transform.position = newPos;
        }

        /// <summary>
        /// Create screen constraints so the player does not go out of bounds
        /// </summary>
        private void InitBounds()
        {
            Camera camera = Camera.main;
            minBounds = camera.ViewportToWorldPoint(new Vector3(0,0,1));
            maxBounds = camera.ViewportToWorldPoint(new Vector3(1, 1,1));
        }


        private void OnMove(InputValue inputValue)
        {
            moveInput = inputValue.Get<Vector2>();

        }
        private void OnFire(InputValue inputValue)
        {
            shooter.PlayerIsFiring = inputValue.isPressed;
        }


        public Transform GetProjectileSpawnPoint()
        {
            return projectileSpawnPoint;
        }
    }
}

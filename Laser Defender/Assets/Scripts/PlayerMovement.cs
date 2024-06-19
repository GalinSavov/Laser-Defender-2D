using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float moveSpeed = 5f;

        private Vector2 moveInput;
        void Start()
        {
            
        }


        private void OnMove(InputValue inputValue)
        {
            moveInput = inputValue.Get<Vector2>();

            if(moveInput.y != 0 || moveInput.x != 0)
            {
                rb.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

        }
    }
}

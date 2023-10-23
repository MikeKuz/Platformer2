﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Platformer2.Inputs
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movements vars")]
        [SerializeField] private float jumpForce;
        [SerializeField] private bool isGrounded = false;
        [SerializeField] private float speed;

        [Header("Settings")]
        [SerializeField] private Transform groundColliderTransform;
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private float jumpOffset;
        [SerializeField] private LayerMask groundMask;

        private Rigidbody2D rb;


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            
        }

        private void FixedUpdate()
        {
            //Jump
            Vector3 overlapCirclePosition = groundColliderTransform.position;
            isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
        }

        public void Move(float direction, bool isJumpButtonPressed)
        {
            //jump
            if(isJumpButtonPressed) 
            {
                Jump();
            }
            //Horizontal movement
            if(Mathf.Abs(direction) > 0.01f)
            {
                HorizontalMovement(direction);
            }
            
        }

        private void Jump()
        {
            if(isGrounded)
            { 
                rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
            }
        }

        private void HorizontalMovement(float direction)
        {
            rb.velocity = new Vector2(curve.Evaluate(direction)*speed, rb.velocity.y);
        }
    }
}
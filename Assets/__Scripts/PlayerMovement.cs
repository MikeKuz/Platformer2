using System.Collections;
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
        [SerializeField] private bool isRun = false;
        [SerializeField] private float speed;

        [Header("Settings")]
        [SerializeField] private Transform groundColliderTransform;
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private float jumpOffset;
        [SerializeField] private LayerMask groundMask;

        private Rigidbody2D rb;
        //private Animator animator;
        private AnimationChanger animationChanger;
        //private SpriteRenderer sr;
        private bool _backwards = false;
        private FirePoint flipPoint;

        public bool Backwards { get => _backwards; set => _backwards = value; }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animationChanger = GetComponent<AnimationChanger>();
            //animator = GetComponent<Animator>();   
            //sr = GetComponent<SpriteRenderer>();
            flipPoint = GameObject.Find("FirePoint").GetComponent<FirePoint>();

            
        }

        private void FixedUpdate()
        {
            //Jump
            Vector3 overlapCirclePosition = groundColliderTransform.position;
            //isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
            isGrounded=CheckingPlayerOnGround(overlapCirclePosition);
            ComlianceCheck(isGrounded);
            //animationChanger.isGrounded = isGrounded;
            //animator.SetBool("isGrounded", isGrounded);
            //animationChanger.NotJump();
        }

        public void Move(float direction, bool isJumpButtonPressed)
        {
            //jump
            if(isJumpButtonPressed) 
            {
                Jump();
            }
            //Horizontal movement
            if(Mathf.Abs(direction) > 0.1f)
            {
                HorizontalMovement(direction);
                isRun = true;
                //animator.SetBool("isRun", isRun);
                animationChanger.IsRun();

                //if (direction > 0 && Backwards)
                //{
                //    Backwards = false;
                //    FlipSprite(Backwards);
                    
                //}

                //if (direction < 0 && !Backwards)
                //{
                //    Backwards = true;
                //    FlipSprite(Backwards);
                //}

            }

            else
            {
                if (isRun)
                {
                    isRun = false;
                    //animator.SetBool("isRun", false);
                    animationChanger.NotRun();

                }
            }

            
        }

        //private void FlipSprite(bool flip)
        //{
        //    //sr.flipX = flip;
        //    flipPoint.MirrorFirePoint(flip);
        //}

        private void Jump()
        {
            if(isGrounded)
            { 
                rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
                animationChanger.Jump();
            }
        }

        private void HorizontalMovement(float direction)
        {
            rb.velocity = new Vector2(curve.Evaluate(direction)*speed, rb.velocity.y);
        }

        private bool CheckingPlayerOnGround(Vector3 overlapCirclePosition)
        {
            return Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
        }

        private void ComlianceCheck(bool isGrounded)
        {
            if(isGrounded==animationChanger.isGrounded)
            {
                return;
            }
            else
            {
                animationChanger.isGrounded=isGrounded;
                animationChanger.ChangeJumpAnimation(isGrounded);
            } 
                
        }
    }
}
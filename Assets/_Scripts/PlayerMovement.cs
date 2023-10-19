using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2.Inputs
{
    //[RequireComponent(typeof(Rigidbody))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 20)] private float speed = 3.0f;
        [SerializeField, Range(0, 20)] private float JumpPoewr = 2.0f;
        private Rigidbody2D playerRigidbody2D;
        static public bool underControl = true;
        static bool jumpIsOn = true;

        private void Awake()
        {
            playerRigidbody2D = GetComponent<Rigidbody2D>();
            TurnOnUnderControl();
        }

        public void MoveCharacter(Vector2 movement)
        {
            if (underControl == true)
            {
                //playerRigidbody2D.AddRelativeForce(movement * speed);
                Vector2 targetVelocity = new Vector2(movement.x*speed, movement.y);
                playerRigidbody2D.velocity = targetVelocity;
            }
        }

        public void JumpCharacter()
        {
            if (underControl == true)
            {
                if (jumpIsOn)
                {
                    playerRigidbody2D.AddForce(new Vector2(0, 100 * JumpPoewr));
                    Debug.Log("пробел нажат");

                }
            }
        }

        static public void TurnOffUnderControl()
        {
            underControl = false;
        }

        static public void TurnOnUnderControl()
        {
            underControl = true;
        }

        static public void TurnOffJump()
        {
            jumpIsOn = false;
        }

        static public void TurnOnJump()
        {
            jumpIsOn = true;
        }
    }
}
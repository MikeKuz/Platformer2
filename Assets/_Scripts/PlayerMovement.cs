using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2.Inputs
{
    //[RequireComponent(typeof(Rigidbody))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private float speed = 0.0f;
        [SerializeField, Range(0, 100)] private float JumpPower = 0.0f;
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
                Vector2 targetVelocity = new Vector2(movement.x*speed, movement.y*JumpPower);
                playerRigidbody2D.velocity = targetVelocity;
            }
        }

        public float JumpCharacter()
        {
            if (underControl == true)
            {
                if (jumpIsOn)
                {
                    //playerRigidbody2D.AddForce(new Vector2(0, 100 * JumpPoewr));
                    Vector2 targetVelocity = new Vector2(0, JumpPower);
                    playerRigidbody2D.velocity = targetVelocity;
                    return JumpPower;
                }
            }
            return 0;
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
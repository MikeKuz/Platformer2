using UnityEngine;

namespace Platformer2.Inputs
{
    //[RequireComponent(typeof(PlayerMovement))]

    public class PlayerInput : MonoBehaviour
    {
        private Vector3 movment;
        private PlayerMovement playerMovement;
        public bool EPressed;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
        void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAZ_AXIS);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerMovement.JumpCharacter();
            }

            if (Input.GetKey(KeyCode.E))
            {
                //TurnOffControlScript.EIsPressed = true;
            }

            else if (Input.GetKeyUp(KeyCode.E))
            {
                //TurnOffControlScript.EIsPressed = false;
            }

            movment = new Vector2(horizontal, 0).normalized;
        }

        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(movment);
        }
    }
}
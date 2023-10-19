using UnityEngine;

namespace Platformer2.Inputs
{
    //[RequireComponent(typeof(PlayerMovement))]

    public class PlayerInput : MonoBehaviour
    {
        private Vector2 movment;
        private PlayerMovement playerMovement;
        public bool EPressed;
        float vertical = 0f;
        float horizontal = 0f;


        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
        void Update()
        {
            vertical = 0;
            horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            //float vertical = Input.GetAxis(GlobalStringVars.VERTICAZ_AXIS);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                vertical = playerMovement.JumpCharacter();
                Debug.Log("Клавиша пробел нажата");
                
            }

            if (Input.GetKey(KeyCode.E))
            {
                //TurnOffControlScript.EIsPressed = true;
            }

            else if (Input.GetKeyUp(KeyCode.E))
            {
                //TurnOffControlScript.EIsPressed = false;
            }

            movment = new Vector2(horizontal, vertical).normalized;
        }

        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(movment);
        }
    }
}
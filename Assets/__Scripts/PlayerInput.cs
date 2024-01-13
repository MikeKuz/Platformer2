using UnityEngine;

namespace Platformer2.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(Shooter))]
    [RequireComponent(typeof(Aim))]
    //[RequireComponent(typeof(DirectionController))]

    public class PlayerInput : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private Shooter shooter;
        //[SerializeField] private bool backwards = false;
        //private DirectionController directionController;
        private AnimationChanger animationChanger;
        public Transform playerPosition;
        public new Camera camera;
        public Vector2 mousePosition;
        private Aim aim;


        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            shooter = GetComponent<Shooter>();
            //directionController = GetComponent<DirectionController>();
            aim=GetComponent<Aim>();
            animationChanger = GetComponent<AnimationChanger>();

        }

        private void Start()
        {
            camera = Camera.main;
            playerPosition = gameObject.transform;
        }

        private void Update()
        {

            float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON);

            Vector3 screnMousePosition = (Input.mousePosition);
            Vector3 directionFromPlayerToAim = DirectionFromPlayerToAim(screnMousePosition);

            if (Input.GetButton(GlobalStringVars.FIRE_1))
            {
                //shooter.Shoot(horizontalDirection);
                shooter.Shoot();
            }

            if(Input.GetButtonUp(GlobalStringVars.FIRE_1))
            {
                shooter.isShooting = false;
            }
            playerMovement.Move(horizontalDirection, isJumpButtonPressed);


            //IsAimLooksBack(directionFromPlayerToAim);

            SendDirectionOnAim(directionFromPlayerToAim);

            //ComlianceCheck(backwards);

        }

        private void SendDirectionOnAim(Vector3 directionFromPlayerToAim)
        {
            aim.directionFromPlayerToAim = directionFromPlayerToAim;
        }

        private Vector3 DirectionFromPlayerToAim(Vector3 screnMousePosition)
        {
            return camera.ScreenToWorldPoint(screnMousePosition) - playerPosition.position;
        }

        //private void IsAimLooksBack(Vector3 directionFromPlayerToAim)
        //{
        //    if (directionFromPlayerToAim.x < 0)
        //    {
        //        if (backwards == false)
        //        {
        //            TurnBackwards();
        //        }

        //    }

        //    else if (directionFromPlayerToAim.x > 0)
        //    {
        //        if (backwards == true)
        //        {
        //            TurnBackwards();
        //        }

        //    }

        //   ChangeBoolInAnimationChanger(backwards);


        //}

        //private void TurnBackwards()
        //{
        //    backwards = !backwards;
        //}

    }
        
}
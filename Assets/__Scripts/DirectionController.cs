using UnityEngine;

namespace Platformer2.Inputs
{
    public class DirectionController :MonoBehaviour
    {
        private SpriteRenderer sr;

        [SerializeField]public bool backwards;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();

        }

        private void Update()
        {

        }
        public void CheckPlayerDirection()
        {

        }

        public void ChangePlayerDirection()
        {

        }

        public void FlipSprite()
        {
            backwards = !backwards;
            Debug.Log(backwards);
            sr.flipX = backwards;
        }
    }
}
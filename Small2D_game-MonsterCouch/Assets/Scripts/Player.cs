using UnityEngine;

namespace small.game2D
{
    public class Player : Character, CharacterMovement
    {
        protected override void Update()
        {
            Movement();
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
        }

        public void Movement()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            transform.Translate(Vector3.right * moveX * characterSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * moveY * characterSpeed * Time.deltaTime);
        }
    }
}

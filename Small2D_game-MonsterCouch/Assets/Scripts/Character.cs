using UnityEngine;

namespace small.game2D
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer characterSprite;

        private Vector2 _screenBoundaries;
        private float _characterWidth;
        private float _characterHeight;

        protected float characterSpeed = 5.0f;
        protected Vector3 characterPosition;

        protected virtual void Start()
        {
            Camera mainCam = Camera.main;
            Vector3 screenSize = new Vector3(Screen.width, Screen.height, mainCam.transform.position.z);
            _screenBoundaries = mainCam.ScreenToWorldPoint(screenSize);

            _characterWidth = characterSprite.bounds.size.x;
            _characterHeight = characterSprite.bounds.size.y;
        }

        protected virtual void Update()
        {

        }

        protected virtual void LateUpdate()
        {
            CharacterBoundaries();
        }

        private void CharacterBoundaries()
        {
            characterPosition = transform.position;
            characterPosition.x = Mathf.Clamp(characterPosition.x, -_screenBoundaries.x + _characterWidth, _screenBoundaries.x - _characterWidth);
            characterPosition.y = Mathf.Clamp(characterPosition.y, -_screenBoundaries.y + _characterHeight, _screenBoundaries.y - _characterHeight);
            transform.position = characterPosition;
        }
    }
}
using UnityEngine;
using System.Collections;

namespace small.game2D
{
    public class Enemy : Character, CharacterMovement
    {
        [SerializeField] private CircleCollider2D enemyCol;

        private int _minRandom = 0;
        private int _maxRandom = 100;
        private float _minTimeRandom = 0.5f;
        private float _maxTimeRandom = 2.0f;
        private float _moveX;
        private float _moveY;
        private float _randomTimeX;
        private float _randomTimeY;
        private bool _canRun = true;

        protected override void Start()
        {
            base.Start();
            _randomTimeX = Random.Range(_minTimeRandom, _maxTimeRandom);
            _randomTimeY = Random.Range(_minTimeRandom, _maxTimeRandom);
            characterSpeed = 4.0f;
        }

        protected override void Update()
        {
            if (_canRun)
                Movement();
        }

        protected override void LateUpdate()
        {
            if (_randomTimeX > 0.0f)
            {
                _randomTimeX -= Time.deltaTime;
            }
            else
            {
                StartCoroutine(Co_RandomDirectionX());
            }

            if (_randomTimeY > 0.0f)
            {
                _randomTimeY -= Time.deltaTime;
            }
            else
            {
                StartCoroutine(Co_RandomDirectionY());
            }

            base.LateUpdate();
        }

        public void Movement()
        {
            transform.Translate(Vector3.right * _moveX * characterSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * _moveY * characterSpeed * Time.deltaTime);
        }

        public void EnemyCaught()
        {
            _canRun = false;
            enemyCol.enabled = false;
        }

        private IEnumerator Co_RandomDirectionX()
        {
            _randomTimeX = Random.Range(_minTimeRandom, _maxTimeRandom);
            yield return new WaitForSeconds(_randomTimeX);

            int randomX = Random.Range(_minRandom, _maxRandom);

            if (randomX > 0 && randomX < 40)
            {
                _moveX = 1.0f;
            }
            else if (randomX >= 40 && randomX < 80)
            {
                _moveX = -1.0f;
            }
            else
            {
                _moveX = 0.0f;
            }
        }

        private IEnumerator Co_RandomDirectionY()
        {
            _randomTimeY = Random.Range(_minTimeRandom, _maxTimeRandom);
            yield return new WaitForSeconds(_randomTimeY);

            int randomY = Random.Range(_minRandom, _maxRandom);

            if (randomY > 0 && randomY < 40)
            {
                _moveY = 1.0f;
            }
            else if (randomY >= 40 && randomY < 80)
            {
                _moveY = -1.0f;
            }
            else
            {
                _moveY = 0.0f;
            }
        }
    }
}
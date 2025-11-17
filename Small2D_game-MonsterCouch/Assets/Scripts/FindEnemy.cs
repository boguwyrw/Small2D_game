using UnityEngine;

namespace small.game2D
{
    public class FindEnemy : MonoBehaviour
    {
        [SerializeField] private LayerMask enemyLayer;

        private float range;

        private void Start()
        {
            range = transform.localScale.x;
        }

        private void FixedUpdate()
        {
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);

            if (enemiesInRange.Length > 0)
            {
                for (int i = 0; i < enemiesInRange.Length; i++)
                {
                    Enemy enemy = enemiesInRange[i].transform.GetComponent<Enemy>();
                    enemy.EnemyCaught();
                }
            }
        }
    }
}

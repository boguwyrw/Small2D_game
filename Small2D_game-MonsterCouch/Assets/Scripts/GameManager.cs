using UnityEngine;
using UnityEngine.SceneManagement;

namespace small.game2D
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private string mainMenuSceneName = "MainMenu";
        [SerializeField] private GameObject enemy;

        private void Start()
        {
            SpawnEnemies();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(mainMenuSceneName);
            }
        }

        private void SpawnEnemies()
        {

        }
    }
}
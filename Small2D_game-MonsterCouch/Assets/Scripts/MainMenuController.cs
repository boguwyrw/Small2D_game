using UnityEngine;
using UnityEngine.SceneManagement;

namespace small.game2D
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private string gameSceneName = "Game";

        [SerializeField] private GameObject buttonsPanel;
        [SerializeField] private GameObject settingsPanel;

        private void Start()
        {
            buttonsPanel.SetActive(true);
            settingsPanel.SetActive(false);
        }

        public void PlayButton()
        {
            SceneManager.LoadScene(gameSceneName);
        }

        public void SettingsButton()
        {
            buttonsPanel.SetActive(false);
            settingsPanel.SetActive(true);
        }

        public void BackButton()
        {
            buttonsPanel.SetActive(true);
            settingsPanel.SetActive(false);
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
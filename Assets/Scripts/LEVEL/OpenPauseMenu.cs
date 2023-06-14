using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseGameMenu;
    [HideInInspector]
    public bool PauseGame;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void LoadMenuScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    private void ResumeToGame()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
        TouchProduct.isPause = false;
        Patience.isPause = false;
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
        TouchProduct.isPause = true;
        Patience.isPause = true;
    }

    public void Resume()
    {
        Invoke("ResumeToGame", 0.5f);
    }

    public void ExitToMenu()
    {
        Invoke("LoadMenuScene", 0.5f);
    }
}
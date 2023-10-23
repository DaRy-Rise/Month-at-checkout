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
        Time.timeScale = 1f;
        PauseGame = false;
        TouchProduct.isPause = false;
        Patience.isPause = false;
        pauseGameMenu.SetActive(false);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private void OnEnable()
    {
        TutorialManager.onEndOfLevel += LoadScene;
    }

    private void OnDisable()
    {
        TutorialManager.onEndOfLevel -= LoadScene;
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToMenu()
    {
        Invoke("LoadScene", 0.5f);
    }
}

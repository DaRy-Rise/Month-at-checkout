using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndChecker : MonoBehaviour
{
    [SerializeField]
    private AudioSource endOfLevelSound;

    private void OnEnable()
    {
        CustomerSpawner.onEndOfLevel += EndOfLevel;
    }
    private void OnDisable()
    {
        CustomerSpawner.onEndOfLevel -= EndOfLevel;
    }

    public void EndOfLevel()
    {
        endOfLevelSound.Play();
        Invoke("LoadNextScene",1.9f);
    }
    private void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }  
}
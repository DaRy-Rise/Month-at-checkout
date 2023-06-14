using UnityEngine;
using UnityEngine.SceneManagement;

public class SetLanguage : MonoBehaviour
{
    private int language;

    private void SelectRussian()
    {
        language = 0;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene(0);
    }

    private void SelectEnglish()
    {
        language = 1;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene(0);
    }

    public void RussianLanguage()
    {
        Invoke("SelectRussian", 0.5f);
    }

    public void EnglishLanguage()
    {
        Invoke("SelectEnglish", 0.5f);
    }
}
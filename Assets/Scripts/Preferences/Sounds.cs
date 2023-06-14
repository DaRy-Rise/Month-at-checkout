using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource[] audioSource;

    private void Start()
    {
        audioSource = GetComponentsInChildren<AudioSource>();
        if (PlayerPrefs.GetInt("music", 1) == 1)
        {
            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < audioSource.Length; i++)
            {
                audioSource[i].enabled = false;
            }
        }
    }
}

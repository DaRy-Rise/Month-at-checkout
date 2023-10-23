using UnityEngine;

public class CommonButtonClick : MonoBehaviour
{
    [SerializeField]
    private AudioSource click;

    public void Click()
    {
        if (PlayerPrefs.GetInt("music") == 1)
        {
            click.Play();
        }
    }
}
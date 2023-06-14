using UnityEngine;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour
{
    [SerializeField]
    private Sprite onMusic;
    [SerializeField]
    private Sprite offMusic;
    private int isOn;

    private void Start()
    {
        isOn = PlayerPrefs.GetInt("music", 1);
        if (isOn == 1)
        {
            gameObject.GetComponent<Image>().sprite = onMusic;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = offMusic;

        }
    }

    private void TurnOff()
    {
        isOn = 0;
        PlayerPrefs.SetInt("music", 0);
        gameObject.GetComponent<Image>().sprite = offMusic;
    }

    private void TurnOn()
    {
        isOn = 1;
        PlayerPrefs.SetInt("music", 1);
        gameObject.GetComponent<Image>().sprite = onMusic;
    }

    public void Click()
    {
        if (isOn == 0)
        {
            TurnOn();
        }
        else
        {
            TurnOff();
        }
    }
}

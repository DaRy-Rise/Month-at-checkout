using TMPro;
using UnityEngine;

public class EnterNumber : MonoBehaviour
{
    private Number number;
    public AudioSource beep;
    public TextMeshProUGUI code;

    private void Start()
    {
        number = GetComponent<Number>();
    }

    public void Enter()
    {
        code.text += number.number;
        if (PlayerPrefs.GetInt("music") == 1)
            beep.Play();
    }
}
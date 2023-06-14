using TMPro;
using UnityEngine;


public class Language : MonoBehaviour
{
    private int language;
    public string[] text;
    private TextMeshProUGUI textLine;

    private void Start()
    {
        language = PlayerPrefs.GetInt("language", language);
        textLine = GetComponent<TextMeshProUGUI>();
        textLine.text = "" + text[language];
    }
}
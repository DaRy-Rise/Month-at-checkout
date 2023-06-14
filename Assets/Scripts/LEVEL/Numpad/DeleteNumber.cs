using TMPro;
using UnityEngine;

public class DeleteNumber : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI code;
    public AudioSource beepSound;

    public void Delete()
    {
        beepSound.Play();
        if (code.text != string.Empty)
        {
            code.text = code.text[..^1];
        }
    } 
}
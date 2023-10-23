using System;
using TMPro;
using UnityEngine;

public class EnterCode : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI code, enteredCode;
    [SerializeField]
    private GameObject numpad, baseWindow, counter, infoOfProduct;
    [SerializeField]
    private ScannerTrigger scanner;
    public AudioSource rightSound, wrongSound;
    public static Action onEnterCode;

    public void Enter()
    {
        if (code.text.Replace(" ", "") == enteredCode.text && !ProductSpawner.haveAntiThief && ProductSpawner.product.tag == "Product")
        {
            scanner.Scan();
            numpad.SetActive(false);
            baseWindow.SetActive(true);
            counter.SetActive(true);
            infoOfProduct.SetActive(true);
            ProductSpawner.isGood = true;
            code.text = string.Empty;
            enteredCode.text = string.Empty;
            if (PlayerPrefs.GetInt("music") == 1)
                rightSound.Play();
        }
        else
        {
            if (PlayerPrefs.GetInt("music") == 1)
                wrongSound.Play();
        }

        onEnterCode?.Invoke();
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

public class CardHoldTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioSource startPaySound, stopPaySound;
    [SerializeField]
    private Image indicators;
    private GameObject barPrefab, bar;
    public static Action onProcess;

    private void Start()
    {
        barPrefab = Resources.Load<GameObject>("Prefab/CardProcessBar/CardProcessBar");
    }
    private void OnDisable()
    {
        indicators.sprite = Resources.Load<Sprite>($"CardIndicators/CardDefaultIndicators");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CardToHold")
        {
            indicators.sprite = Resources.Load<Sprite>($"CardIndicators/CardStart");
            bar = Instantiate(barPrefab, new Vector2(143.6f, 406.8f), Quaternion.identity);
            if (PlayerPrefs.GetInt("music") == 1)
                startPaySound.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "CardToHold")
        {
            onProcess?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "CardToHold")
        {
            indicators.sprite = Resources.Load<Sprite>($"CardIndicators/CardStop");
            if (PlayerPrefs.GetInt("music") == 1)
                stopPaySound.Play();
            Destroy(bar);
        } 
    }
}
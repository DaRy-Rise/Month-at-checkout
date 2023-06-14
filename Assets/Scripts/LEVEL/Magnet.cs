using System;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField]
    private GameObject highlight;
    [SerializeField]
    private AudioSource beepSound;
    public static bool isWork;
    public static Action onClickMagnet;
    public static Action onClickFirstLevel;

    private void Start()
    {
        TurnMagnetOff();
    }
    private void OnEnable()
    {
        AntiThief.onTrigger += TurnMagnetOff;
    }
    private void OnDisable()
    {
        AntiThief.onTrigger -= TurnMagnetOff;
    }

    public void TurnMagnetOn()
    {
        if (SetGetInfo.currentLevel <3)
        {
            onClickFirstLevel?.Invoke();
        }
        onClickMagnet?.Invoke();
        if (ProductSpawner.haveAntiThief)
        {
            isWork = true;
            beepSound.Play();
            highlight.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    public void TurnMagnetOff()
    {
        isWork = false;
        highlight.GetComponent<SpriteRenderer>().enabled = false;       
    }
}
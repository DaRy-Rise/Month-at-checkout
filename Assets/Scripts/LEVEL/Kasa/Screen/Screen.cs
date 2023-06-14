using UnityEngine;
using System;

public class Screen : MonoBehaviour
{
    [SerializeField]
    private GameObject errorImage, rebootButton;
    [SerializeField]
    private AudioSource errorSound, startUpSound;
    private Animator animator;
    public static Action onFixError;

    private void OnEnable()
    {
        ScreenErrorManager.onThrowError += ThrowError;
        animator = GetComponent<Animator>();
        errorImage.SetActive(false);
    }

    private void OnDisable()
    {
        ScreenErrorManager.onThrowError -= ThrowError;
    }

    public void ThrowError()
    {
        animator.enabled = false;
        errorImage.SetActive(true);
        errorSound.Play();
    }

    public void StartLoad()
    {
        animator.enabled = true;
        errorImage.SetActive(false);
        animator.SetBool("toLoad", true);
        Invoke("PlayStartUpSound", 2);
        Invoke("FixError", 4.1f);
    }

    public void FixError()
    {
        onFixError?.Invoke();
    }

    public void SetBoolFalse()
    {
        animator.SetBool("toLoad", false);
    }

    public void PlayStartUpSound()
    {
        startUpSound.Play();
    }
}
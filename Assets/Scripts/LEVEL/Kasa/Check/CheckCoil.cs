using System;
using UnityEngine;
using UnityEngine.UI;

public class CheckCoil : MonoBehaviour
{
    [SerializeField]
    private Button dropButton, setButton;
    [SerializeField]
    private GameObject panel;
    private Animator animator;
    public static Action onFix;

    private void Start()
    {
        TurnBtnOff();
        animator = GetComponent<Animator>();
        dropButton.enabled = true;
        panel.SetActive(false);
    }

    private void OnEnable()
    {
        CheckSwipeDetector.onSwipe += RollCoil;
    }

    private void OnDisable()
    {
        CheckSwipeDetector.onSwipe -= RollCoil;
    }

    private void TurnBtnOff()
    {
        setButton.enabled = false;
        dropButton.enabled = false;
    }

    public void DropEmptyCoil()
    {
        animator.SetBool("toDrop", true);
        dropButton.enabled = false;
        setButton.enabled = true;
    }

    public void SetNewCoil()
    {
        TurnBtnOff();
        animator.SetBool("toSet", true);
        panel.SetActive(true);
    }
    public void RollCoil()
    {
        animator.SetBool("toSwipe", true);
    }

    public void SetBoolFalse()
    {
        animator.SetBool("toDrop", false);
        animator.SetBool("toSet", false);
    }

    public void CloseWindow()
    {
        SetBoolFalse();
        onFix?.Invoke();
    }
}
using System;
using UnityEngine;

public class ScreenErrorManager : MonoBehaviour
{
    private bool isFirstScreenError;
    [SerializeField]
    private GameObject screen, numpad, changeMenu, baseWindow, productWindow;
    [HideInInspector]
    public static int count, maxCountOfScreenErrors;
    [HideInInspector]
    public static float chanceOfScreenError;
    [HideInInspector]
    public static bool isError;
    public static Action onThrowError, onFirstScreenError;

    private void Awake()
    {
        isError = false;
        screen.SetActive(false);
        if (SetGetInfo.currentLevel < 5)
        {
            chanceOfScreenError = 0;
        }
        if (SetGetInfo.currentLevel == 5)
        {
            chanceOfScreenError = 100;
            isFirstScreenError = true;
        }
    }

    private void OnEnable()
    {
        ClickCard.onClickCard += CheckChance;
        ConfirmPay.onConfirm += CheckChance;
        EnterCode.onEnterCode += CheckChance;
        DeleteProduct.onClickDelete += CheckChance;
        Magnet.onClickMagnet += CheckChance;
        Screen.onFixError += FixScreenError;
    }

    private void OnDisable()
    {
        ClickCard.onClickCard -= CheckChance;
        ConfirmPay.onConfirm -= CheckChance;
        EnterCode.onEnterCode -= CheckChance;
        DeleteProduct.onClickDelete -= CheckChance;
        Magnet.onClickMagnet -= CheckChance;
        Screen.onFixError -= FixScreenError;
    }

    private void CheckChance()
    {
        int i = UnityEngine.Random.Range(1, 100);
        if (i <= chanceOfScreenError && count < maxCountOfScreenErrors && !isError)
        {
            ThrowScreenError();
        }
    }

    public void ThrowScreenError()
    {
        screen.SetActive(true);
        numpad.SetActive(false);
        changeMenu.SetActive(false);
        baseWindow.SetActive(false);
        productWindow.SetActive(false);
        onThrowError?.Invoke();
        count++;
        isError = true;
        if (isFirstScreenError)
        {
            onFirstScreenError?.Invoke();
            isFirstScreenError = false;
        }
    }

    public void FixScreenError()
    {
        isError = false;
        screen.SetActive(false);
        baseWindow.SetActive(true);
    } 
}
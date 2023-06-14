using System;
using UnityEngine;

public class ClickCash : MonoBehaviour
{
    [SerializeField]
    private GameObject moneyCase, changeMenu;
    [SerializeField]
    private Change change;
    public AudioSource openSound;
    public static Action onClickCash;

    public void Click()
    {
        if (GeneratorInfoCustomer.methodOfPayment == MethodPayment.cash)
        {
            onClickCash?.Invoke();
            changeMenu.SetActive(true);
            moneyCase.SetActive(true);
            change.GetInfo();
            openSound.Play();
            GeneratorInfoCustomer.methodOfPayment = null;
        }
    }
}
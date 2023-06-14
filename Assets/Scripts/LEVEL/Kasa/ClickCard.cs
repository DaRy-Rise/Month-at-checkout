using System;
using UnityEngine;

public class ClickCard : MonoBehaviour
{
    private CounterProductPrice counter;
    [SerializeField]
    private GameObject kasaLight;
    public AudioSource beepSound;
    public static Action onClickCard;

    private void Start()
    {
        InvokeRepeating("TurnOff", 0, 0.5f);
        counter = FindAnyObjectByType<CounterProductPrice>();   
    }

    private void OnEnable()
    {
        CardHoldManager.onConfirmPay += ConfirmPay;
    }

    private void OnDisable()
    {
        CardHoldManager.onConfirmPay -= ConfirmPay;
    }

    private void TurnOff()
    {
        kasaLight.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Click()
    {
        if (GeneratorInfoCustomer.methodOfPayment == MethodPayment.card && !CheckErrorManager.isError)
        {
            onClickCard?.Invoke();
        }
    }

    public void ConfirmPay()
    {
        GeneratorInfoCustomer.methodOfPayment = null;
        GeneratorInfoCustomer.doesPay = true;
        kasaLight.GetComponent<SpriteRenderer>().enabled = true;
        beepSound.Play();
        SetGetInfo.customers += 1;
        SetGetInfo.kasaShouldBe += float.Parse(counter.sum.text);
        SetGetInfo.currentKasa += float.Parse(counter.sum.text);
    }
}
using System;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    [SerializeField]
    private GameObject card;
    [SerializeField]
    private GameObject cash;
    [SerializeField]
    private GameObject bag;
    [SerializeField]
    private GameObject cloud;
    [SerializeField]
    private GameObject couponButton;
    public static Action onShowBag;
    public static Action onFirstBag;
    public static Action onFirstCoupon;
    public static Action onFirstScreenError;

    private void Start()
    {
        TurnOffEverything();
    }

    private void OnEnable()
    {
        DeleteProduct.onEndOfProductsToPay += TurnPayCloudOn;
        Product.onEndOfProducts += TurnPayCloudOn;
        CouponManager.onEndCouponEvent += TurnPayCloudOn;
        ClickCard.onClickCard += TurnOffEverything;
        ClickCash.onClickCash += TurnOffEverything;
        BagManager.onStart += TurnOffEverything;
        BagOnMainWindow.onLastStage += TurnPayCloudOn;
    }

    private void OnDisable()
    {
        DeleteProduct.onEndOfProductsToPay -= TurnPayCloudOn;
        Product.onEndOfProducts -= TurnPayCloudOn;
        CouponManager.onEndCouponEvent -= TurnPayCloudOn;
        ClickCard.onClickCard -= TurnOffEverything;
        ClickCash.onClickCash -= TurnOffEverything;
        BagManager.onStart -= TurnOffEverything;
        BagOnMainWindow.onLastStage -= TurnPayCloudOn;
    }

    private void SetMethodImage()
    {
        if (GeneratorInfoCustomer.methodOfPayment == MethodPayment.card)
        {
            card.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (GeneratorInfoCustomer.methodOfPayment == MethodPayment.cash)
        {
            cash.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void TurnOffEverything()
    {
        card.GetComponent<SpriteRenderer>().enabled = false;
        cash.GetComponent<SpriteRenderer>().enabled = false;
        cloud.GetComponent<SpriteRenderer>().enabled = false;
        bag.GetComponent<SpriteRenderer>().enabled = false;
    }
    public void TurnPayCloudOn()
    {
        if(BagManager.isBag && !CounterProductPrice.isZero)
        {

            cloud.GetComponent<SpriteRenderer>().enabled = true;
            bag.GetComponent<SpriteRenderer>().enabled = true;
            onShowBag?.Invoke();
            if (BagManager.isFirstBag)
            {
                onFirstBag?.Invoke();
                BagManager.isFirstBag = false;
            }
        }    
        else if (CouponManager.isCoupon && !CounterProductPrice.isZero)
        {
            cloud.GetComponent<SpriteRenderer>().enabled = true;
            couponButton.SetActive(true);
            if (CouponManager.isFirstCoupon)
            {
                onFirstCoupon?.Invoke();
                CouponManager.isFirstCoupon = false;
            }
        }
        else
        {
            if (!CounterProductPrice.isZero)
            {
                GeneratorInfoCustomer.countOfProduct = -1;
                GeneratorInfoCustomer.GetMethod();
                cloud.GetComponent<SpriteRenderer>().enabled = true;
                SetMethodImage();
            }
        }
    }
}

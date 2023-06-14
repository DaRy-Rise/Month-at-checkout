using System;
using TMPro;
using UnityEngine;

public class CounterProductPrice : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI sum;
    public static bool isZero;

    private void Start()
    {
        SetZero();
    }

    private void OnEnable()
    {
        CouponManager.onAcceptCoupon += ApplyCoupon;
    }

    private void OnDisable()
    {
        CouponManager.onAcceptCoupon -= ApplyCoupon;
    }

    private void Update()
    {
        if (GeneratorInfoCustomer.doesPay == true)
        {
            SetZero();
        }
        if (sum.text == "0")
        {
            isZero = true;
        }
        else
        {
            isZero = false;
        }
    }

    private void SetZero()
    {
        sum.text = "0";
    }

    public void Plus(float price)
    {
        float isum = (float)Math.Round(float.Parse(sum.text), 2) + (float)Math.Round(price, 2);
        sum.text = ((float)Math.Round(isum, 2)).ToString();
    }

    public void ApplyCoupon()
    {
        sum.text = Math.Round(float.Parse(sum.text) - float.Parse(sum.text) * CouponWindow.discountValue / 100, 2).ToString();
    }
}
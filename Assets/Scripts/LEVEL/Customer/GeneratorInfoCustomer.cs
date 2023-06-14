using System;
using UnityEngine;

public class GeneratorInfoCustomer : MonoBehaviour
{
    public static int countOfProduct = 1, minRange = 1, maxRange = 5;
    public static bool doesPay = false;
    public static MethodPayment? methodOfPayment;
    public static ChanceOfMethodPayment methodsOffset;
    public static int chanceOfCash;
    public static Action onGenerateInfo;

    private static void FillMethods()
    {
        switch (methodsOffset)
        {
            case ChanceOfMethodPayment.Half:
                chanceOfCash = 50;
                break;
            case ChanceOfMethodPayment.MoreCash:
                chanceOfCash = 80;
                break;
            case ChanceOfMethodPayment.MoreCard:
                chanceOfCash = 20;
                break;
            case ChanceOfMethodPayment.FullCard:
                chanceOfCash = 0;
                break;
            case ChanceOfMethodPayment.FullCash:
                chanceOfCash = 100;
                break;
            default:
                break;
        }
    }

    public static void GetCount()
    {
        countOfProduct = UnityEngine.Random.Range(minRange, maxRange);
    }

    public static void GetMethod()
    {
        FillMethods();
        int i = UnityEngine.Random.Range(0, 100);
        if (i <= chanceOfCash)
        {
            methodOfPayment = MethodPayment.cash;
        }
        else
        {
            methodOfPayment = MethodPayment.card;
        }
    }

    public static void GetInfoAboutCouponAndBag()
    {
        onGenerateInfo?.Invoke();
    } 
}
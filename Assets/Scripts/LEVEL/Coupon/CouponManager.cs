using System;
using UnityEngine;

public class CouponManager : MonoBehaviour
{
    public static float chanceOfCoupon, chanceOfGoodCoupon;
    public static bool isCoupon, isGoodCoupon;
    public static bool isFirstCoupon;
    public static Action onAcceptCoupon, onEndCouponEvent;

    private void Awake()
    {
        if (SetGetInfo.currentLevel <4)
        {
            chanceOfCoupon = 0;
        }
        if (SetGetInfo.currentLevel == 4)
        {
            chanceOfCoupon = 100;
            isFirstCoupon = true;
        }
    }

    private void OnEnable()
    {
        GeneratorInfoCustomer.onGenerateInfo += GenerateCoupon;
    }

    private void OnDisable()
    {
        GeneratorInfoCustomer.onGenerateInfo -= GenerateCoupon;
    }

    public void GenerateCoupon()
    {
        int i = UnityEngine.Random.Range(1, 100);

        if (i <= chanceOfCoupon)
        {
            isCoupon = true;
        }
        else
        {
            isCoupon = false;
        }
        GenerateCouponStatus();   
    }

    public static void GenerateCouponStatus()
    {
        int i = UnityEngine.Random.Range(0, 100);

        if (i <= chanceOfGoodCoupon)
        {
            isGoodCoupon = true;
        }
        else
        {
            isGoodCoupon = false;
        }
    }

    public void Accept()
    {
        onAcceptCoupon?.Invoke();
        if (!isGoodCoupon)
        {
            KarmaPoints.ShowPoints(PointsToKarma.Minus);
        }
        isCoupon = false;
        onEndCouponEvent?.Invoke();
    }

    public void Decline()
    {      
        if (isGoodCoupon)
        {
            KarmaPoints.ShowPoints(PointsToKarma.Minus);
            Karma.countOfDeclingGoodCoupon++;
        }
        isCoupon = false;
        onEndCouponEvent?.Invoke();
    }
}

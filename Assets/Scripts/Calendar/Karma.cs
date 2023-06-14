using UnityEngine;

public class Karma : MonoBehaviour
{
    private static float karma;
    public static int countWrongDeletedProduct;
    public static int uvbeenNoticed;
    public static int numberOfSoldAlcoholToChild;
    public static int countOfDeclingGoodCoupon;

    private void Start()
    {
        uvbeenNoticed = 0;
        numberOfSoldAlcoholToChild = 0;
        countWrongDeletedProduct = 0;
        karma = SetGetInfo.globalInfo.info.karma;
    }

    public static void CalculateKarma()
    {
        if (SetGetInfo.currentKasa - SetGetInfo.kasaShouldBe == 0)
        {
            karma++;
        }
        else
        {
            karma += (SetGetInfo.currentKasa - SetGetInfo.kasaShouldBe) * 2;
        }
        karma += uvbeenNoticed * (-2);
        karma -= countWrongDeletedProduct;
        karma -= countOfDeclingGoodCoupon * 2;
        if (SetGetInfo.customers == GradeAfterLevel.countOfCustomersShouldBe)
        {
            karma ++;
        }
        else
        {
            karma -= 2;
        }
        if (karma > 100)
        {
            karma = 100;
        }
        else if (karma < 0)
        {
            karma = 0;
        }
        SetGetInfo.karma = karma;
    }
}
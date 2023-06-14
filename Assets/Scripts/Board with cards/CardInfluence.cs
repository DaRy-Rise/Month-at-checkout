using UnityEngine;

public class CardInfluence : MonoBehaviour
{
   private static void SetBad()
    {
        switch (GenerateCardInfo.id)
        {
            case 0: GeneratorInfoCustomer.methodsOffset = ChanceOfMethodPayment.MoreCash;
                break;
            case 1:
                GeneratorInfoCustomer.methodsOffset = ChanceOfMethodPayment.FullCash;
                break;
            case 2: ProductSpawner.kindOffset = KindOfBarCode.MoreBad;
                break;
            case 3:
                Patience.kindOfPatience = PatienceKind.Impatient;
                break;
            case 4:
                ConfirmPay.chanceKind = ChanceKind.Suspicion;
                break;
            case 5:
                GeneratorInfoCustomer.minRange = 5;
                GeneratorInfoCustomer.maxRange = 16;
                break;
            case 6: NumpadPositions.toMix = true;
                break;
            case 7:
               ProductSpawner.alwaysAntiThief = true;
                break;
            case 8:
                ScreenErrorManager.chanceOfScreenError = 30;
                break;
            case 9:
                CheckErrorManager.chanceOfCheckError = 40;
                break;
            case 10:
                CouponManager.chanceOfCoupon = 50;
                break;
            case 11:
                BagManager.chanceOfBag = 70;
                break;
            case 12:
                MoneyCase.isClosed = true;
                break;
            case 13:
                CardProcessBar.maxSpeed = 0.5f;
                CardProcessBar.minSpeed = 0.1f;
                break;
            default:
                break;
        }
    }

    private static void SetGood()
    {
        switch (GenerateCardInfo.id)
        {
            case 0:
                GeneratorInfoCustomer.methodsOffset = ChanceOfMethodPayment.MoreCard;
                break;
            case 1:
                GeneratorInfoCustomer.methodsOffset = ChanceOfMethodPayment.FullCard;
                break;
            case 2:
                ProductSpawner.kindOffset = KindOfBarCode.AllGood;
                break;
            case 3:
                Patience.kindOfPatience = PatienceKind.Patient;
                break;
            case 4:
                ConfirmPay.chanceKind = ChanceKind.Naive;
                break;
            case 5:
                GeneratorInfoCustomer.minRange = 1;
                GeneratorInfoCustomer.maxRange = 6;
                break;
            case 6:
                GenerateCode.lenghtOfCode = Random.Range(3, 6);
                break;
            case 7:
                ProductSpawner.turnOffAntiThief = true;
                break;
            case 8:
                ScreenErrorManager.chanceOfScreenError = 0;
                break;
            case 9:
                CheckErrorManager.chanceOfCheckError = 0;
                break;
            case 10:
                CouponManager.chanceOfCoupon = 0;
                break;
            case 11:
                BagManager.chanceOfBag = 0;
                break;
            case 13:
                CardProcessBar.maxSpeed = 2f;
                CardProcessBar.minSpeed = 1.3f;
                break;
            default:
                break;
        }
    }

    private static void SetDefault()
    {
        GeneratorInfoCustomer.methodsOffset = ChanceOfMethodPayment.Half;
        ProductSpawner.kindOffset = KindOfBarCode.Default;
        GeneratorInfoCustomer.minRange = 1;
        GeneratorInfoCustomer.maxRange = 11;
        NumpadPositions.toMix = false;
        BagManager.chanceOfBag = 40;
        ScreenErrorManager.chanceOfScreenError = 5;
        ScreenErrorManager.maxCountOfScreenErrors = 2;
        CheckErrorManager.chanceOfCheckError = 10;
        CheckErrorManager.maxCountOfCheckErrors = 1;
        CouponManager.chanceOfCoupon = 20;
        CouponManager.chanceOfGoodCoupon = 70;
        CouponWindow.chanceOfBadData = 40;
        CouponWindow.chanceOfBadQR = 40;
        MoneyCase.isClosed = false;
        CardProcessBar.maxSpeed = 1;
        CardProcessBar.minSpeed = 0.5f;
    }

    public static void SetInfluence()
    {
        SetDefault();
        if (GenerateCardInfo.isGood)
        {
            SetGood();
        }
        else
        {
            SetBad();
        }
    }
}
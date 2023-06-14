using System;
using UnityEngine;

public class ConfirmPay : MonoBehaviour
{
    [SerializeField]
    private GameObject changeMenu, moneyCase;
    [SerializeField]
    private Change change;
    [SerializeField]
    private CounterProductPrice counter;
    public static int chanceOfNotice;
    public static ChanceKind chanceKind;
    public static Action onConfirm, onPickWrongChange;

    public void Confirm()
    {
        if (!CheckErrorManager.isError)
        {
            CheckIsChangeCorrect();
            onConfirm?.Invoke();
            changeMenu.SetActive(false);
            moneyCase.SetActive(false);
            GeneratorInfoCustomer.doesPay = true;
            change.change = 0;
            SetGetInfo.customers += 1;
        }      
    }

    private void CheckIsChangeCorrect()
    {
        if (change.change == float.Parse(change.toChange.text))
        {
            SetGetInfo.kasaShouldBe += float.Parse(counter.sum.text);
            SetGetInfo.currentKasa += float.Parse(counter.sum.text);
        }
        else if (change.change < float.Parse(change.toChange.text))
        {
            PickChance();
        }
        else if (change.change > float.Parse(change.toChange.text))
        {
            KarmaPoints.ShowPoints(PointsToKarma.Minus);
            SetGetInfo.kasaShouldBe += (float)Math.Round(float.Parse(counter.sum.text), 2);
            SetGetInfo.currentKasa += (float)Math.Round(float.Parse(counter.sum.text), 2) - change.change;
            Karma.uvbeenNoticed++;
        }
    }

    private void PickChance()
    {
        FillChance();
        int i = UnityEngine.Random.Range(0, 100);
        if (i <= chanceOfNotice)
        {
            KarmaPoints.ShowPoints(PointsToKarma.Minus);
            onPickWrongChange?.Invoke();
        }
        else
        {
            KarmaPoints.ShowPoints(PointsToKarma.Plus);
            SetGetInfo.kasaShouldBe += float.Parse(counter.sum.text);
            SetGetInfo.currentKasa += float.Parse(counter.sum.text) + float.Parse(change.toChange.text) - change.change;
        }
    }

    private void FillChance()
    {
        float odd = float.Parse(change.toChange.text) - change.change;
        int min = (int)ChanceRange.Min;
        int midMin = (int)ChanceRange.MiddleMin;
        int midMax = (int)ChanceRange.MiddleMax;
        int max = (int)ChanceRange.Max;
        switch (chanceKind)
        {
            case ChanceKind.Suspicion:
                midMin = 1;
                midMax = 3;
                max = 5;
                break;
            case ChanceKind.Naive:
                midMin = 3;
                midMax = 7;
                max = 10;
                break;
            default:
                break;
        }
        if (odd >= min && odd < midMin)
        {
            chanceOfNotice = 20;
        }
        else if (odd >= midMin && odd < midMax)
        {
            chanceOfNotice = 40;
        }
        else if (odd >= midMax && odd < max)
        {
            chanceOfNotice = 70;
        }
        else if (odd >= 8)
        {
            chanceOfNotice = 100;
        }
    }
}
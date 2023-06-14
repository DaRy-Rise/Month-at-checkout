using System;
using TMPro;
using UnityEngine;

public class CouponWindow : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro date;
    private GameObject[] couponPrefab;
    private GameObject prefab;
    private Vector2 spawnPoint = new Vector2(143.1f, 331.4f);
    private int index;
    private static bool isBadQR, isBadData;
    [SerializeField]
    public TextMeshPro discount;
    public static float chanceOfBadQR, chanceOfBadData;
    public static int discountValue;

    private void Start()
    {       
        couponPrefab = Resources.LoadAll<GameObject>("Prefab/CouponPrefab");
    }

    private void OnEnable()
    {
        CouponManager.onEndCouponEvent += DestroyCoupon;
    }

    private void OnDisable()
    {
        CouponManager.onEndCouponEvent -= DestroyCoupon;
    }

    private void SetCouponStatus()
    {
        if (CouponManager.isGoodCoupon)
        {           
            prefab = Instantiate(couponPrefab[0], spawnPoint, Quaternion.identity);
        }
        else
        {
            GenerateQRStatus();
            if (isBadQR)
            {
                GenerateDataStatus();
            }
            else
            {
                isBadData = true;
            }
            index = UnityEngine.Random.Range(1, couponPrefab.Length);
            prefab = Instantiate(couponPrefab[index], spawnPoint, Quaternion.identity);
        }
    }

    private void GenerateDataValue()
    {
        DateTime dateTime = DateTime.Today;
        int maxDay = 30;
        int maxMonth = 12;
        int maxYear = 6;
        if (isBadData)
        {
            maxDay = -30;
            maxMonth = -12;
            maxYear = -6;
        }
        int countOfChangingData = UnityEngine.Random.Range(1, 4);
        for (int j = 1; j <= countOfChangingData; j++)
        {
            int i = UnityEngine.Random.Range(0, 3);
            switch (i)
            {
                case 0:
                    dateTime = dateTime.AddDays(UnityEngine.Random.Range(0, maxDay));
                    break;
                case 1:
                    dateTime = dateTime.AddMonths(UnityEngine.Random.Range(0, maxMonth));
                    break;
                case 2:
                    dateTime = dateTime.AddYears(UnityEngine.Random.Range(0, maxYear));
                    break;
                default:
                    break;
            }
        }
        date.text = dateTime.ToShortDateString().ToString();
    }
    private void GenerateDicsountValue()
    {
        discountValue = UnityEngine.Random.Range(1, 30);
        discount.text = discountValue.ToString();
        discount.text += "%";
    }

    private void GenerateQRStatus()
    {
        int i = UnityEngine.Random.Range(0, 100);
        if (i <= chanceOfBadQR)
        {
            isBadQR = true;
        }
        else
        {
            isBadQR = false;
        }
    }

    private void GenerateDataStatus()
    {
        int i = UnityEngine.Random.Range(0, 100);
        if (i <= chanceOfBadData)
        {
            isBadData = true;
        }
        else
        {
            isBadData = false;
        }
    }

    public void ShowCoupon()
    {
        SetCouponStatus();
        GenerateDataValue();
        GenerateDicsountValue();
    }

    public void DestroyCoupon()
    {
        Destroy(prefab);
    }
}

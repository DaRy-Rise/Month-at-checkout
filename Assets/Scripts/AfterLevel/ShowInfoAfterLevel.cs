using System;
using TMPro;
using UnityEngine;

public class ShowInfoAfterLevel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI customers;
    [SerializeField]
    private TextMeshProUGUI total;

    private void Start()
    {
        total.text = ((float)Math.Round(SetGetInfo.currentKasa - SetGetInfo.kasaShouldBe, 2)).ToString();
        customers.text = SetGetInfo.customers.ToString();
    }
}
using System;
using TMPro;
using UnityEngine;

public class StatInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI customers;
    [SerializeField]
    private TextMeshProUGUI income;
    [SerializeField]
    private TextMeshProUGUI karma;

    private void Start()
    {
        customers.text = SetGetInfo.totalCustomers.ToString();
        karma.text = ((float)Math.Round(SetGetInfo.karma)).ToString();
        income.text = ((float)Math.Round(SetGetInfo.income)).ToString();
    }
}
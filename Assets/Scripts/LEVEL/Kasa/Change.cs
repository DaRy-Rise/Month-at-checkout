using System;
using TMPro;
using UnityEngine;

public class Change : MonoBehaviour
{
    [HideInInspector]
    public float change;
    [SerializeField]
    private TextMeshProUGUI total, sum, paid;
    [SerializeField]
    public TextMeshProUGUI toChange;

    public void GetInfo()
    {
        SetPayedSum();
        sum.text = total.text;
        CountChange();
    }

    private void CountChange()
    {
        float changeF = (float)Math.Round(float.Parse(paid.text), 2) - (float)Math.Round(float.Parse(sum.text),2);
        toChange.text = ((float)Math.Round(changeF, 2)).ToString();
    }

    private void SetPayedSum()
    {
        int percent = UnityEngine.Random.Range(0, 101);
        float toPay = float.Parse(total.text);
        paid.text = Math.Round(UnityEngine.Random.Range(toPay, toPay * (100 + percent) / 100), 2).ToString();
    }
    public void SetChange(float nominal)
    {
        change += nominal;
        change = (float)Math.Round(change, 2);
    }

    public void MinusChange(float nominal)
    {
        change -= nominal;
        change = (float)Math.Round(change, 2);
    }
}
using TMPro;
using UnityEngine;

public class GenerateCode : MonoBehaviour
{
    private readonly char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    [HideInInspector]
    public static int lenghtOfCode = 6;
    public TextMeshProUGUI code;
    
    public void Generate()
    {
        if (code.text.Length == 0 && ProductSpawner.isGood == false)
        {
            for (int i = 0; i < lenghtOfCode; i++)
            {
                code.text += numbers[Random.Range(0, numbers.Length)];
                code.text += " ";
            }
        }  
    }
}
using System.Collections.Generic;
using UnityEngine;

public class NumpadPositions : MonoBehaviour
{
    private Number[] numbers;
    private static ParsingJson reader;
    private const string path = "Assets/Resources/Json/NumpadPostitions.json";
    public static bool toMix;
    public static Numpad numpad;

    private void Start()
    {
        numbers = GetComponentsInChildren<Number>();
        if (toMix)
        {
            reader = FindAnyObjectByType<ParsingJson>();
            numpad = reader.GetInfo<Numpad>(path);
            List<NumpadButton> buttons = new List<NumpadButton>();
            for (int i = 0; i < numpad.button.Length; i++)
            {
                buttons.Add(numpad.button[i]);
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                int j = Random.Range(0, buttons.Count);
                numbers[i].transform.position = new Vector2(buttons[j].pointX, buttons[j].pointY + 10.9531f);
                buttons.Remove(buttons[j]);
            }
        }
    }
}
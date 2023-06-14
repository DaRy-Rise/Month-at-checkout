using System;
using UnityEngine;

public class Continue : MonoBehaviour
{
    public static Action onClickContinue;
    public void ContinueToCalendar()
    {
        onClickContinue?.Invoke();
    }
}
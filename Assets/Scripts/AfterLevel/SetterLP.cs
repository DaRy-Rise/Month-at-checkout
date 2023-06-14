using System;
using UnityEngine;

public class SetterLP : MonoBehaviour
{
    public static Action onSetInfo;
    private void OnEnable()
    {
        GradeAfterLevel.onRate += SetInfo;
    }
    private void OnDisable()
    {
        GradeAfterLevel.onRate -= SetInfo;
    }
    private void SetInfo()
    {
        Karma.CalculateKarma();
        SetGetInfo.Set();
        if (SetGetInfo.currentLevel >= 5)
        {
            onSetInfo?.Invoke();
        }
    }
}
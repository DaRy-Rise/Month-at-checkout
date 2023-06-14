using System;
using UnityEngine;

public class ProductMenuBtn : MonoBehaviour
{
    public static Action onClickFirstLevel;

    public void CheckIsFirstLevel()
    {
        if (SetGetInfo.currentLevel == 1)
        {
            onClickFirstLevel?.Invoke();
        }
    }
}
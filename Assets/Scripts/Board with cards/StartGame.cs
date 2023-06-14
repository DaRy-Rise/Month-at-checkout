using System;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public static Action onClickStart;
    public void PlayGame()
    {
        onClickStart?.Invoke();
    }
}

using System;
using UnityEngine;

public class MainMenuBtns : MonoBehaviour
{
    public static Action onStartGame;

    private void CloseGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        onStartGame?.Invoke();
    }

    public void ExitGame()
    {
        Invoke("CloseGame", 0.5f);
    }
}
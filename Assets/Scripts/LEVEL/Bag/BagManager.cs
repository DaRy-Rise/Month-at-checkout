using System;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    [SerializeField]
    private GameObject swipeDetector, background;
    [HideInInspector]
    public static float chanceOfBag;
    [HideInInspector]
    public static bool isBag, isFirstBag;
    public static Action onStart;

    private void Awake()
    {
        if (SetGetInfo.currentLevel == 1 || SetGetInfo.currentLevel == 4)
        {
            chanceOfBag = 0;
        }
        if (SetGetInfo.currentLevel == 2)
        {
            chanceOfBag = 100;
            isFirstBag = true;
        }
    }

    private void OnEnable()
    {
        GeneratorInfoCustomer.onGenerateInfo += GenerateBag;
        CloudScript.onShowBag += TurnOnBagPanel;
        PanelBagSwipeDetector.onSwipe += TurnOnBagBaground;
        BagOnMainWindow.onLastStage += TurnOffBagBaground;
    }

    private void OnDisable()
    {
        GeneratorInfoCustomer.onGenerateInfo -= GenerateBag;
        CloudScript.onShowBag -= TurnOnBagPanel;
        PanelBagSwipeDetector.onSwipe -= TurnOnBagBaground;
        BagOnMainWindow.onLastStage -= TurnOffBagBaground;
    }
    public void GenerateBag()
    {
        int i = UnityEngine.Random.Range(1, 100);
        if (i <= chanceOfBag)
        {
            isBag = true;
        }
        else
        {
            isBag = false;
        }
    }
    public void TurnOnBagPanel()
    {      
        swipeDetector.SetActive(true);
    }
    public void TurnOnBagBaground()
    {
        onStart?.Invoke();
        background.SetActive(true);
    }
    public void TurnOffBagBaground()
    {
        background.SetActive(false);
    }
}

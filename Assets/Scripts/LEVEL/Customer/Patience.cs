using System;
using UnityEngine;
using UnityEngine.UI;

public class Patience : MonoBehaviour
{
    private static int level;
    private Image patienceBar;
    private static bool showKarmaPoint;
    private static float patienceLeft = 1, cmax, cmin;
    public static bool isPause, stopReaction;
    public static float maxPatience;
    public static PatienceKind kindOfPatience;
    public static Action onEndOfPatience;

    private void Start()
    {    
        level = SetGetInfo.currentLevel - 1;
        patienceBar = GetComponent<Image>();
    }

    private void Update()
    {
        if (patienceLeft > 0 && GeneratorInfoCustomer.doesPay == false && !isPause)
        {
            patienceLeft -= Time.deltaTime;
            patienceBar.fillAmount = patienceLeft / maxPatience;
        }
        else if(patienceLeft <= 0 && !stopReaction)
        {
            onEndOfPatience?.Invoke();
            if (!showKarmaPoint)
            {
                KarmaPoints.ShowPoints(PointsToKarma.Minus);
                showKarmaPoint = true;
            }           
        }      
    }

    private static void SetPatienceLevel()
    {
        switch (kindOfPatience)
        {
            case PatienceKind.Patient:
                cmax = SetGetInfo.levelInfo.level[level].coefficientMaxTime * 1.5f;
                cmin = SetGetInfo.levelInfo.level[level].coefficientMinTime * 1.5f;
                break;
            case PatienceKind.Impatient:
                cmax = SetGetInfo.levelInfo.level[level].coefficientMaxTime / 1.5f;
                cmin = SetGetInfo.levelInfo.level[level].coefficientMinTime / 1.5f;
                break;
            case PatienceKind.Default:
                cmax = SetGetInfo.levelInfo.level[level].coefficientMaxTime;
                cmin = SetGetInfo.levelInfo.level[level].coefficientMinTime;
                break;
            default:
                break;
        }
    }

    public static void SetMaxPatience()
    {
        maxPatience = 0;
        int countOfProduct = GeneratorInfoCustomer.countOfProduct;
        float min = countOfProduct * cmin;
        float max = countOfProduct * cmax;
        maxPatience = UnityEngine.Random.Range(min, max+1);
    }

    public static void ResetPatience()
    {
        SetPatienceLevel();
        SetMaxPatience();
        patienceLeft = maxPatience;
        showKarmaPoint = false;
    }

    public static void Fine(int percent)
    {
        patienceLeft -= (patienceLeft / 100) * percent;
    }
}
using UnityEngine;

public class CCheckerEndOfGame : MonoBehaviour
{
    public static bool isEndOfGame;

    private void OnEnable()
    {
        SetterLP.onSetInfo += CheckIsEnd;
    }

    private void OnDisable()
    {
        SetterLP.onSetInfo -= CheckIsEnd;
    }

    private void CheckIsEnd()
    {
        int countOfCLevel = 0;
        for (int i = SetGetInfo.currentLevel - 1; i > 0; i--)
        {
            if (SetGetInfo.globalInfo.info.levelStat[i-1].grade == "C")
            {
                countOfCLevel++;
                continue;
            }
            else
            {
                isEndOfGame = false;
                break;
            }
        }
        if (countOfCLevel == 5)
        {
            isEndOfGame = true;
            SetGetInfo.SetDefault();
        }
    }
}

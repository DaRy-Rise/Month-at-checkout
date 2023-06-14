using System;
using UnityEngine;

public class SetGetInfo : MonoBehaviour
{
    private static ParsingJson reader;
    private const string globalInfoPath = "Assets/Resources/Json/GlobalInfo.json";
    private const string levelInfoPath = "Assets/Resources/Json/LevelInfo.json";
    public static int currentLevel;
    public static int nextlevel;
    public static string grade;
    public static int customers;
    public static float kasaShouldBe;
    public static float currentKasa;
    public static float karma;
    public static float income;
    public static int totalCustomers;   
    public static GlobalInfo globalInfo;
    public static LevelsInfo levelInfo;

    private void Awake()
    {
        kasaShouldBe = 0;
        customers = 0;
        currentKasa = 0;
        reader = FindAnyObjectByType<ParsingJson>();
        globalInfo = reader.GetInfo<GlobalInfo>(globalInfoPath);
        levelInfo = reader.GetInfo<LevelsInfo>(levelInfoPath);
        currentLevel = globalInfo.info.currentLevel;
        income = globalInfo.info.income;
        totalCustomers = globalInfo.info.totalCustomers;
        karma = globalInfo.info.karma;
        nextlevel = currentLevel + 1;
    }

    public static void Set()
    {
        globalInfo.info.totalCustomers += customers;
        globalInfo.info.income += (float)Math.Round(currentKasa, 2);
        globalInfo.info.karma = (float)Math.Round(karma);
        globalInfo.info.levelStat[currentLevel - 1].grade = grade;
        globalInfo.info.levelStat[currentLevel - 1].kasa = (float)Math.Round(currentKasa - kasaShouldBe, 2);
        globalInfo.info.levelStat[currentLevel - 1].customers = customers;
        globalInfo.info.currentLevel = nextlevel;
        reader.SetInfo(globalInfo, globalInfoPath);
    }

    public static void SetDefault()
    {
        for (int i = 0; i < currentLevel - 1; i++)
        {
            globalInfo.info.levelStat[i].grade = "";
            globalInfo.info.levelStat[i].kasa = 0;
            globalInfo.info.levelStat[i].customers = 0;
        }
        globalInfo.info.totalCustomers = 0;
        globalInfo.info.income = 0;
        globalInfo.info.karma = 50;
        globalInfo.info.currentLevel = 1;
        reader.SetInfo(globalInfo, globalInfoPath);
    }
}
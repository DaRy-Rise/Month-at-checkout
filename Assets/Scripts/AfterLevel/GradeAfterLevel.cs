using System;
using UnityEngine;

public class GradeAfterLevel : MonoBehaviour
{
    [SerializeField]
    private AudioSource markA;
    [SerializeField]
    private AudioSource markB;
    [SerializeField]
    private AudioSource markC;
    public static int countOfCustomersShouldBe;
    public static Action onRate;

    private void Start()
    {
        countOfCustomersShouldBe = SetGetInfo.levelInfo.level[SetGetInfo.currentLevel - 1].countOfCustomers;
        Rate();
        ShowMark();
    }

    public static void Rate()
    {
        if (SetGetInfo.customers == 0)
        {
            SetGetInfo.grade = "C";
        }
        if (SetGetInfo.customers == countOfCustomersShouldBe && SetGetInfo.currentKasa - SetGetInfo.kasaShouldBe >= 0)
        {
            SetGetInfo.grade = "A";
        }
        else if (SetGetInfo.customers == countOfCustomersShouldBe || SetGetInfo.currentKasa - SetGetInfo.kasaShouldBe >= 0)
        {
            SetGetInfo.grade = "B";
        }
        else
        {
            SetGetInfo.grade = "C";
        }
        onRate?.Invoke();
    }

    public void ShowMark()
    {
        if (SetGetInfo.grade == "A")
        {
            if (PlayerPrefs.GetInt("music") == 1)
                markA.Play();
            Instantiate(Resources.Load<GameObject>("Prefab/GradePrefab/ABC/AAfter"), new Vector2(0,0), Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("Prefab/GradePrefab/EllipsAfter"), new Vector2(0, 0), Quaternion.identity);
        }
        else if (SetGetInfo.grade == "B")
        {
            if (PlayerPrefs.GetInt("music") == 1)
                markB.Play();
            Instantiate(Resources.Load<GameObject>("Prefab/GradePrefab/ABC/BAfter"), new Vector2(0, 0), Quaternion.identity);
        }
        else if (SetGetInfo.grade == "C")
        {
            if (PlayerPrefs.GetInt("music") == 1)
                markC.Play();
            Instantiate(Resources.Load<GameObject>("Prefab/GradePrefab/ABC/CAfter"), new Vector2(0, 0), Quaternion.identity);
        }
    }
}
using UnityEngine;

public class Grade : MonoBehaviour
{
    [SerializeField]
    private float xPoint;
    public int numberOfDay;

    private void Start()
    {       
        if (numberOfDay < SetGetInfo.nextlevel)
        {
            ShowAllGradeInfo();
        }
    }

    private void ShowAllGradeInfo()
    {        
        switch (SetGetInfo.globalInfo.info.levelStat[numberOfDay - 1].grade)
        {
            case "A":
                SetGrade(Rating.A);
                break;
            case "B":
                SetGrade(Rating.B);
                break;
            case "C":
                SetGrade(Rating.C);
                break;
            default:
                break;
        }
    }

    private void SetGrade(Rating rating)
    {        
        float y = 0;
        switch (numberOfDay)
        {
            case <= 5: 
                y = 407.5f;
                break;
            case <= 10:
                y = 338.6f;
                break;
            case <= 15:
                y = 269.7f;
                break;
            case <= 20:
                y = 200.8f;
                break;
            case <= 25:
                y = 131.9f;
                break;
            case <= 30:
                y = 63f;
                break;
            default:
                break;
        }
        Vector2 spawnPoint = new Vector2(xPoint, y);
        switch (rating)
        {
            case Rating.A:
                Instantiate(Resources.Load<GameObject>("Prefab/GradePrefab/ABC/A"), spawnPoint, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("Prefab/GradePrefab/Ellips"), spawnPoint, Quaternion.identity);
                break;
            case Rating.B:
                Instantiate(Resources.Load<GameObject>("Prefab/GradePrefab/ABC/B"), spawnPoint, Quaternion.identity);
                break;
            case Rating.C:
                Instantiate(Resources.Load<GameObject>("Prefab/GradePrefab/ABC/C"), spawnPoint, Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
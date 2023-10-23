using System;
using UnityEngine;

public class ChooseDay : MonoBehaviour
{
    [SerializeField]
    private AudioSource click;
    private Grade grade;
    public static Action onChooseDay;

    private void Start()
    {
        grade = GetComponentInChildren<Grade>();
    }

    public void Choose()
    {
        if (grade.numberOfDay == SetGetInfo.currentLevel)
        {
            if (PlayerPrefs.GetInt("music") == 1)
            {
                click.Play();
            }
            onChooseDay?.Invoke();
        }      
    }
}

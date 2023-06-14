using System;
using UnityEngine;
using UnityEngine.UI;

public class CheckErrorManager : MonoBehaviour
{
    private bool isFirstCheckError;
    [SerializeField]
    private AudioSource breakingSound;
    [SerializeField]
    private Button button;
    [SerializeField]
    private GameObject checkWindow;
    private Image image;
    [HideInInspector]
    public int count;
    [HideInInspector]
    public static float chanceOfCheckError;
    [HideInInspector]
    public static int maxCountOfCheckErrors;
    [HideInInspector]
    public static bool isError;
    public static Action onFirstCheckError, onFix;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.enabled = false;
        button.enabled = false;
        checkWindow.SetActive(false);
        if (SetGetInfo.currentLevel < 5)
        {
            chanceOfCheckError = 0;
        }
        if (SetGetInfo.currentLevel == 5)
        {
            chanceOfCheckError = 100;
            isFirstCheckError = true;
        }
    }

    private void OnEnable()
    {
        CheckCoil.onFix += FixError;
        Check.onSpawn += CheckChance;
    }

    private void OnDisable()
    {
        CheckCoil.onFix -= FixError;
        Check.onSpawn -= CheckChance;
    }

    private void ThrowAttention()
    {
        if (!isError && count < maxCountOfCheckErrors)
        {
            breakingSound.Play();
            image.enabled = true;
            button.enabled = true;
            count++;
            isError = true;
            if (isFirstCheckError)
            {
                onFirstCheckError?.Invoke();
                isFirstCheckError = false;
            }
        }   
    }

    private void CheckChance()
    {
        int i = UnityEngine.Random.Range(1, 100);

        if (i <= chanceOfCheckError)
        {
            ThrowAttention();
        }
    }

    public void OpenCheckWindow()
    {
        checkWindow.SetActive(true);
    }

    public void FixError()
    {
        isError = false;
        image.enabled = false;
        button.enabled = false;
        checkWindow.SetActive(false);
        onFix?.Invoke();
    }
}
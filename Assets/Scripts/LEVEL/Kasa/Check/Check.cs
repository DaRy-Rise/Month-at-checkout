using System;
using UnityEngine;

public class Check : MonoBehaviour
{
    [SerializeField]
    private GameObject swipePanel;
    [SerializeField]
    private AudioSource tearSound, printSound;
    private Vector2 spawnPoint = new Vector2(260.5f, 199.6f);
    [HideInInspector]
    public GameObject check;  
    [HideInInspector]
    public static bool isExist;
    public static Action onTearOff, onSpawn;

    private void Start()
    {
        swipePanel.SetActive(false);
        isExist = false;
        check = Resources.Load<GameObject>("Prefab/CheckPrefab/Check");
    }

    private void OnEnable()
    {
        CheckMainWindowSwipeDetector.onSwipe += TearOff;
        ConfirmPay.onConfirm += Spawn;
        CardHoldManager.onConfirmPay += Spawn;
        CheckErrorManager.onFix += Spawn;
    }

    private void OnDisable()
    {
        CheckMainWindowSwipeDetector.onSwipe -= TearOff;
        ConfirmPay.onConfirm -= Spawn;
        CardHoldManager.onConfirmPay -= Spawn;
        CheckErrorManager.onFix -= Spawn;
    }
    private void Spawn()
    {
        onSpawn?.Invoke();
        if (!CheckErrorManager.isError)
        {
            if (PlayerPrefs.GetInt("music") == 1)
            {
                printSound.Play();
            }
            Invoke("SetReadyToSwipe", 0.36f);
            Instantiate(check, spawnPoint, Quaternion.identity);
        }      
    }
    private void SetReadyToSwipe()
    {
        swipePanel.SetActive(true);
    }

    public void TearOff()
    {
        if (PlayerPrefs.GetInt("music") == 1)
        {
            tearSound.Play();
        }
        swipePanel.SetActive(false);
        onTearOff?.Invoke();
    }
}
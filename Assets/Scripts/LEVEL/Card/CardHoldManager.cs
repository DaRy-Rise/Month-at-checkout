using System;
using UnityEngine;

public class CardHoldManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource successPaySound;
    [SerializeField]
    private GameObject backGround, trigger;
    [SerializeField]
    private GameObject indicators;
    private GameObject card;
    private GameObject[] cardPrefab;
    public static Action onConfirmPay;

    private void Start()
    {
        indicators.SetActive(false);
        backGround.SetActive(false);
        trigger.SetActive(false);
        cardPrefab = Resources.LoadAll<GameObject>("Prefab/CardPrefab");
    }

    private void OnEnable()
    {
        ClickCard.onClickCard += OpenCardHoldWindow;
        CardProcessBar.onEndProcess += ConfirmPay;
    }

    private void OnDisable()
    {
        ClickCard.onClickCard -= OpenCardHoldWindow;
        CardProcessBar.onEndProcess -= ConfirmPay;
    }

    private void OpenCardHoldWindow()
    {
        backGround.SetActive(true);
        trigger.SetActive(true);
        indicators.SetActive(true);
        int index = UnityEngine.Random.Range(0, cardPrefab.Length);
        card = Instantiate(cardPrefab[index], new Vector2(90.7f, 168.5f), Quaternion.identity);
    }

    private void ConfirmPay()
    {
        successPaySound.Play();
        Destroy(card);
        backGround.SetActive(false);
        trigger.SetActive(false);
        indicators.SetActive(false);
        onConfirmPay?.Invoke();
    }
}
using TMPro;
using UnityEngine;

public class InfoForCard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI info;
    [SerializeField]
    private TextMeshProUGUI nameOfCard;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        info.text = GenerateCardInfo.text;
        nameOfCard.text = GenerateCardInfo.nameOfCard;
    }
}
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class TwinCard : MonoBehaviour
{
    [SerializeField]
    private AudioSource click;
    [SerializeField]
    private InfoForCard info;
    private static bool first;
    private bool isActive = false;
    public BackCardSide[] backForCard;   
    public GameObject frontSide; 
    public BackCardSide backSide; 
    public CardSide mCardState = CardSide.Front; 
    public float mTime = 0.3f;

    private IEnumerator ToBack()
    {
        isActive = true;
        frontSide.transform.DORotate(new Vector3(0, 90, 0), mTime);
        for (float i = mTime; i >= 0; i -= Time.deltaTime)
            yield return 0;
        backSide.transform.DORotate(new Vector3(0, 0, 0), mTime);
        isActive = false;
        ShowInfo();
    }

    private IEnumerator ToFront()
    {
        isActive = true;
        backSide.transform.DORotate(new Vector3(0, 90, 0), mTime);
        for (float i = mTime; i >= 0; i -= Time.deltaTime)
            yield return 0;
        frontSide.transform.DORotate(new Vector3(0, 0, 0), mTime);
        isActive = false;
    }

    private void ShowInfo()
    {
        info.Show();
    }

    private void Start()
    {
        first = true;
        if (!GenerateCardInfo.isGenerated)
        {
            GenerateCardInfo.Generate();
            CardInfluence.SetInfluence();
        }
        string path;
        if (GenerateCardInfo.isGood)
        {
            path = "Prefab/BackCardPrefab/Good/";
        }
        else
        {
            path = "Prefab/BackCardPrefab/Bad/";
        }
        backForCard = Resources.LoadAll<BackCardSide>(path);

        for (int i = 0; i < backForCard.Length; i++)
        {
            if (backForCard[i].id == GenerateCardInfo.id)
            {
                backSide = Instantiate(backForCard[i], gameObject.transform.position, Quaternion.identity);
                break;
            }
        }
        Init();      
    }

    public void Init()
    {
        if (mCardState == CardSide.Front)
        {
            frontSide.transform.eulerAngles = Vector3.zero;
            backSide.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else
        {
            frontSide.transform.eulerAngles = new Vector3(0, 90, 0);
            backSide.transform.eulerAngles = Vector3.zero;
        }
    }

    public void StartBack()
    {
        if (first)
        {
            click.Play();
            first = false;
            if (isActive)
                return;
            StartCoroutine(ToBack());
        }
      
    }

    public void StartFront()
    {
        if (isActive)
            return;
        StartCoroutine(ToFront());
    }
}
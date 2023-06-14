using UnityEngine;

public class GenerateCardInfo : MonoBehaviour 
{
    private const int countOfCards = 13;
    private static ParsingJson reader;
    public static bool isGenerated; 
    public static int id;
    public static bool isGood;
    public static string text;
    public static string nameOfCard;
    public static string path;  
    public static float chanceOfGoodCard;    

    private void Start()
    {
        isGenerated = false;
    }

    private static void SetKindOfCard()
    {
        float karma = SetGetInfo.karma;
        chanceOfGoodCard = Mathf.Round(karma);

        int i = Random.Range(0, 100);
        if (i <= chanceOfGoodCard)
        {
            isGood = true;
        }
        else
        {
            isGood = false;
        }
    }

    private static void SetExeptionForlevels()
    {
        while (id >= 7)
        {
            id = Random.Range(0, countOfCards);
        }
    }

    public static void Generate()
    {
        reader = FindAnyObjectByType<ParsingJson>();
        id = Random.Range(0, countOfCards);
        if (SetGetInfo.currentLevel <= 5)
        {
            SetExeptionForlevels();
        }

        SetKindOfCard();

        if (isGood)
        {
            if (PlayerPrefs.GetInt("language", 0) == 0)
            {
                path = "Assets/Resources/Json/Rus/CardInfoGood.json";
            }
            else
            {
                path = "Assets/Resources/Json/Eng/CardInfoGood.json";
            }

        }
        else
        {
            if (PlayerPrefs.GetInt("language", 0) == 0)
            {
                path = "Assets/Resources/Json/Rus/CardInfoBad.json";
            }
            else
            {
                path = "Assets/Resources/Json/Eng/CardInfoBad.json";
            }
        }
        CardInfo cardInfo = reader.GetInfo<CardInfo>(path);
        nameOfCard = cardInfo.card[id].name;
        text = cardInfo.card[id].info;
        isGenerated = true;
    }
}
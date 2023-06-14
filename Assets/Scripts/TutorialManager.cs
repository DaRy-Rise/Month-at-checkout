using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorial;
    [SerializeField]
    private TextMeshPro text;
    [SerializeField]
    private GameObject oldMan;
    [SerializeField]
    private GameObject pauseBack;
    private GameObject pointer;
    private TutorialText tutorialText;
    private static ParsingJson reader;
    private static string path;
    private int index;
    private int numberOfTutor;
    private static bool isWarning;
    public static Action onEndOfLevel;
    private void OnEnable()
    {
        Magnet.onClickFirstLevel += WarningDoNotClick;
        ProductMenuBtn.onClickFirstLevel += WarningDoNotClick;
        CloudScript.onFirstBag += BagTutorial;
        CloudScript.onFirstCoupon += CouponTutorial;
        ScreenErrorManager.onFirstScreenError += ScreenErrorTutorial;
        CheckErrorManager.onFirstCheckError += CheckErrorTutorial;
    }
    private void OnDisable()
    {
        Magnet.onClickFirstLevel -= WarningDoNotClick;
        ProductMenuBtn.onClickFirstLevel -= WarningDoNotClick;
        CloudScript.onFirstBag -= BagTutorial;
        CloudScript.onFirstCoupon -= CouponTutorial;
        ScreenErrorManager.onFirstScreenError -= ScreenErrorTutorial;
        CheckErrorManager.onFirstCheckError -= CheckErrorTutorial;
    }
    private void Awake()
    {
        SetTutorialActive(false);
        isWarning = false;
        index = 0;
        GetNumberOfTutor();
        if (PlayerPrefs.GetInt("language", 0) == 0)
        {
            path = "Assets/Resources/Json/Rus/TutorialText.json";
        }
        else
        {
            path = "Assets/Resources/Json/Eng/TutorialText.json";
        }
        reader = FindAnyObjectByType<ParsingJson>();
        tutorialText = reader.GetInfo<TutorialText>(path);       
        switch (numberOfTutor)
        {
            case 1:
                Pause();
                First();
                break;
            case 2:
                Pause();
                Second();
                break;
            case 3:
                Pause();
                Third();
                break;
            case 4:
                Invoke("Fourth", 0.7f);
                Invoke("Pause", 0.8f);
                break;
            case 5:
                Pause();
                Fifth();
                break;
            default:
                break;
        }
        if (CCheckerEndOfGame.isEndOfGame)
        {
            EndOfLevel();
            CCheckerEndOfGame.isEndOfGame = false;
        }
    }
    private void WarningDoNotClick()
    {
        SetTutorialActive(true);
        SetOldManFace(OldManEmotions.Default3);
        text.text = tutorialText.warningDoNotClick[0].text;
        isWarning = true;
    }
    private void BagTutorial()
    {
        numberOfTutor = 7;
        if (index >= tutorialText.bagTutor.Length)
        {
            Resume();
            SetTutorialActive(false);
            index = 0;
        }
        else
        {
            Pause();
            SetTutorialActive(true);
            SetOldManFace(OldManEmotions.Smile);
            text.text = tutorialText.bagTutor[index].text;
            switch (index)
            {
                case 1:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 2:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 3:
                    SetOldManFace(OldManEmotions.Smile);
                    break;
                case 4:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                default:
                    break;
            }
            index++;
        }
    }
    private void CouponTutorial()
    {
        numberOfTutor = 8;
        if (index >= tutorialText.couponTutor.Length)
        {
            Resume();
            SetTutorialActive(false);
            index = 0;
        }
        else
        {
            Pause();
            SetTutorialActive(true);
            SetOldManFace(OldManEmotions.Default3);
            text.text = tutorialText.couponTutor[index].text;
            switch (index)
            {
                case 1:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 2:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 3:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                case 4:
                    SetOldManFace(OldManEmotions.Smile);
                    break;
                case 5:
                    SetOldManFace(OldManEmotions.MoneyFace);
                    break;
                case 6:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 7:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                case 8:
                    SetOldManFace(OldManEmotions.Happy);
                    break;
                case 9:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 10:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 11:
                    SetOldManFace(OldManEmotions.Smile);
                    break;
                case 12:
                    SetOldManFace(OldManEmotions.AngryAndSmile);
                    break;
                case 13:
                    SetOldManFace(OldManEmotions.MoneyFace);
                    break;
                default:
                    break;
            }
            index++;
        }
    }
    private void ScreenErrorTutorial()
    {
        numberOfTutor = 9;
        if (index >= tutorialText.screenErrorTutor.Length)
        {
            Resume();
            SetTutorialActive(false);
            index = 0;
        }
        else
        {
            Pause();
            SetTutorialActive(true);
            SetOldManFace(OldManEmotions.Default);
            text.text = tutorialText.screenErrorTutor[index].text;
            switch (index)
            {
                case 1:
                    SetOldManFace(OldManEmotions.Angry);
                    break;
                case 3:
                    SetOldManFace(OldManEmotions.AngryAndSmile);
                    break;
                case 4:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 6:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 7:
                    SetOldManFace(OldManEmotions.Smile);
                    break;
                case 9:
                    SetOldManFace(OldManEmotions.AngryAndSmile);
                    break;
                default:
                    break;
            }
            index++;
        }
    }
    private void CheckErrorTutorial()
    {
        numberOfTutor = 10;
        if (index >= tutorialText.checkErrorTutor.Length)
        {
            Resume();
            SetTutorialActive(false);
        }
        else
        {
            Pause();
            SetTutorialActive(true);
            SetOldManFace(OldManEmotions.Default2);
            text.text = tutorialText.checkErrorTutor[index].text;
            switch (index)
            {
                case 1:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 2:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 3:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 4:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                default:
                    break;
            }
            index++;
        }
    }
    private void First()
    {
        if (index >= tutorialText.firstTutor.Length)
        {
            Resume();
            SetTutorialActive(false);
        }
        else
        {
            SetTutorialActive(true);
            SetOldManFace(OldManEmotions.Default);
            oldMan.SetActive(true);
            text.text = tutorialText.firstTutor[index].text;
            switch (index)
            {
                case 2:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 3:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 4:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                case 6:
                    SpawnPointer(145.4f, 414.6f);
                    break;
                case 7:
                    Destroy(pointer);
                    break;
                case 9:
                    SetOldManFace(OldManEmotions.Smile);
                    break;
                case 11:
                    SetOldManFace(OldManEmotions.MoneyFace);
                    break;
                case 12:
                    SetOldManFace(OldManEmotions.Smile);
                    break;
                case 13:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                case 14:
                    SetOldManFace(OldManEmotions.Angry);
                    break;
                case 15:
                    SetOldManFace(OldManEmotions.Angry);
                    break;
                case 16:
                    SetOldManFace(OldManEmotions.AngryAndSmile);
                    break;
                case 17:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 19:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                case 20:
                    SetOldManFace(OldManEmotions.Default2);
                    SpawnPointer(260.9f, 131.4f);
                    break;
                case 21:
                    Destroy(pointer);
                    break;
                case 22:
                    SetOldManFace(OldManEmotions.MoneyFace);
                    break;
                default:
                    break;
            }
            index++;
        }         
    }

    private void Second()
    {
        if (index >= tutorialText.secondTutor.Length)
        {
            Resume();
            SetTutorialActive(false);
        }
        else
        {
            SetTutorialActive(true);
            text.text = tutorialText.secondTutor[index].text;
            switch (index)
            {
                case 0:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                case 1:
                    SetOldManFace(OldManEmotions.Smile);
                    break;
                case 2:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                case 5:
                    SetOldManFace(OldManEmotions.Angry);
                    break;
                case 6:
                    SetOldManFace(OldManEmotions.AngryAndSmile);
                    break;
                default:
                    break;
            }
            index++;
        }
    }
    private void Third()
    {
        if (index >= tutorialText.thirdTutor.Length)
        {
            Destroy(pointer);
            Resume();
            SetTutorialActive(false);
            index = 0;
        }
        else
        {
            SetTutorialActive(true);
            text.text = tutorialText.thirdTutor[index].text;
            switch (index)
            {
                case 0:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                case 1:
                    SetOldManFace(OldManEmotions.Smile);
                    break;
                case 2:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                case 3:
                    SetOldManFace(OldManEmotions.Smile);
                    break;
                case 4:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 5:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 6:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 10:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 13:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 14:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 15:
                    SetOldManFace(OldManEmotions.Default2);
                    SpawnPointer(178f, 323.8f);
                    break;
                default:
                    break;
            }
            index++;
        }
    }
    private void Fourth()
    {
        if (index >= tutorialText.fourthTutor.Length)
        {
            Resume();
            SetTutorialActive(false);
            index = 0;
        }
        else
        {          
            SetTutorialActive(true);
            text.text = tutorialText.fourthTutor[index].text;
            switch (index)
            {
                case 0:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 2:
                    SetOldManFace(OldManEmotions.Angry);
                    break;
                case 3:
                    SetOldManFace(OldManEmotions.Happy);
                    SpawnPointer(201, 217.5f);
                    break;
                case 4:
                    SetOldManFace(OldManEmotions.Default);
                    Destroy(pointer);
                    break;
                case 5:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 6:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 7:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                default:
                    break;
            }
            index++;
        }
    }
    private void Fifth()
    {
        if (index >= tutorialText.fifthTutor.Length)
        {
            Resume();
            SetTutorialActive(false);
            index = 0;
        }
        else
        {
            SetTutorialActive(true);
            text.text = tutorialText.fifthTutor[index].text;
            switch (index)
            {
                case 0:
                    SetOldManFace(OldManEmotions.Default2);
                    break;
                case 1:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                case 2:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 3:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                case 5:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 6:
                    SetOldManFace(OldManEmotions.Default);
                    break;
                case 7:
                    SetOldManFace(OldManEmotions.Default2);
                    SpawnPointer(160, 223);
                    break;
                case 8:
                    Destroy(pointer);
                    break;
                case 9:
                    SpawnPointer(206, 124);
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 10:
                    Destroy(pointer);
                    SetOldManFace(OldManEmotions.Default);
                    break;
                default:
                    break;
            }
            index++;
        }
    }
    public void Next()
    {
        if (isWarning)
        {
            SetTutorialActive(false);
            Resume();
            isWarning = false;
        }
        else
        {
            switch (numberOfTutor)
            {
                case 1:
                    First();
                    break;
                case 2:
                    Second();
                    break;
                case 3:
                    Third();
                    break;
                case 4:
                    Fourth();
                    break;
                case 5:
                    Fifth();
                    break;
                case 7:
                    BagTutorial();
                    break;
                case 8:
                    CouponTutorial();
                    break;
                case 9:
                    ScreenErrorTutorial();
                    break;
                case 10:
                    CheckErrorTutorial();
                    break;
                case 11:
                    EndOfLevel();
                    break;
                case 12:
                    onEndOfLevel?.Invoke(); 
                    break;
                default:
                    break;
            }
        }
    }

    private void EndOfLevel()
    {
        numberOfTutor = 11;
        if (index >= tutorialText.endOfLevel.Length)
        {
            Resume();
            SetTutorialActive(false);
            index = 0;         
        }
        else
        {
            SetTutorialActive(true);
            text.text = tutorialText.endOfLevel[index].text;
            numberOfTutor = 12;
            switch (index)
            {
                case 0: SetOldManFace(OldManEmotions.Angry);
                    break;
                case 1:
                    SetOldManFace(OldManEmotions.Default3);
                    break;
                case 2:
                    SetOldManFace(OldManEmotions.AngryAndSmile);
                    break;
                default:
                    break;
            }
            index++;
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        TouchProduct.isPause = true;
        Patience.isPause = true;
        pauseBack.SetActive(true);       
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        TouchProduct.isPause = false;
        Patience.isPause = false;
        pauseBack.SetActive(false);
    }
    private void SetTutorialActive(bool state)
    {
        tutorial.SetActive(state);
    }
    private void GetNumberOfTutor()
    {
        if (SetGetInfo.currentLevel == 1 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            numberOfTutor = 1;
        }
        else if (SetGetInfo.currentLevel == 2 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            numberOfTutor = 2;
        }
        else if (SetGetInfo.currentLevel == 2 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            numberOfTutor = 3;
        }
        else if (SetGetInfo.currentLevel == 2 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            numberOfTutor = 4;
        }
        else if (SetGetInfo.currentLevel == 3 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            numberOfTutor = 5;
        }
    }
    private void SetOldManFace(OldManEmotions oldManEmotions)
    {
        switch (oldManEmotions)
        {
            case OldManEmotions.Default:
                oldMan.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("OldMan/OldMan0");
                break;
            case OldManEmotions.Default2:
                oldMan.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("OldMan/OldManSpeak1");
                break;
            case OldManEmotions.Default3:
                oldMan.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("OldMan/OldManSpeak2");
                break;
            case OldManEmotions.Smile:
                oldMan.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("OldMan/OldManSmile");
                break;
            case OldManEmotions.Angry:
                oldMan.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("OldMan/OldManAngry");
                break;
            case OldManEmotions.AngryAndSmile:
                oldMan.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("OldMan/OldManAngryAndSmile");
                break;
            case OldManEmotions.MoneyFace:
                oldMan.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("OldMan/OldManMoney");
                break;
            case OldManEmotions.Happy:
                oldMan.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("OldMan/OldManHappy");
                break;
            default:
                break;
        }
    }

    private void SpawnPointer(float x, float y)
    {
        pointer = Instantiate(Resources.Load<GameObject>("Prefab/PointerPrefab/Pointer"), new Vector2(x,y), Quaternion.Euler(0, 0, 90));
    }
}

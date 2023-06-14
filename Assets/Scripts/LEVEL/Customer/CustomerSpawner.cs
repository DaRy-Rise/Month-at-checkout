using System;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    private Vector2 spawnPoint;
    private const float spawnX = 385f;
    private static int level;
    [HideInInspector]
    public GameObject[] skeletPrefab, hats, faces, facesColor, tors;
    [HideInInspector]
    public GameObject customerPrefab, customer;
    [HideInInspector]
    public static bool isChild, readyForProduct;
    [HideInInspector]
    public static int countOfCustomer;
    public static int chanceOfChild;
    public static Action onEndOfLevel;

    private void Start()
    {
        level = SetGetInfo.currentLevel - 1;
        customerPrefab = Resources.Load<GameObject>("Prefab/CustomerPrefab/Customer");
        skeletPrefab = Resources.LoadAll<GameObject>("Prefab/CustomerPrefab/Skelet");
        hats = Resources.LoadAll<GameObject>("Prefab/CustomerPrefab/Clothes/Hats");
        faces = Resources.LoadAll<GameObject>("Prefab/CustomerPrefab/Clothes/Faces");
        facesColor = Resources.LoadAll<GameObject>("Prefab/CustomerPrefab/Clothes/FacesColor");
        tors = Resources.LoadAll<GameObject>("Prefab/CustomerPrefab/Clothes/Torso");
        countOfCustomer = SetGetInfo.levelInfo.level[level].countOfCustomers;
        SetChance();
        Spawn();
    }

    private void Update()
    {
        if (customer == null && countOfCustomer != 0)
        {
            Spawn();
        }
    }

    private void OnEnable()
    {
        CustomerMove.onLeave += CheckIsEnd;
    }

    private void OnDisable()
    {
        CustomerMove.onLeave += CheckIsEnd;
    }

    private void SetParametersBeforeSpawn()
    {
        readyForProduct = true;
        Patience.ResetPatience();
        countOfCustomer -= 1;
        GeneratorInfoCustomer.doesPay = false;
    }

    private void CheckIsEnd()
    {
        if (countOfCustomer == 0)
        {
            GeneratorInfoCustomer.doesPay = false;
            onEndOfLevel?.Invoke();
        }
    }

    private static void SetChance()
    {
        chanceOfChild = 30;
    }

    private int SpawnChild()
    {
        for (int j = 0; j < skeletPrefab.Length; j++)
        {
            if (skeletPrefab[j].name == "Child")
            {
                return j;
            }
        }
        return -1;
    }
    public void Spawn()
    {
        spawnPoint = new Vector2(30, -10);
        customer = Instantiate(customerPrefab, spawnPoint, Quaternion.identity);
        SpawnSkelet();
        SpawnHats();
        SpawnFaces();
        SpawnFacesColor();
        SpawnTors();
        GeneratorInfoCustomer.GetCount();
        GeneratorInfoCustomer.GetInfoAboutCouponAndBag();
        SetParametersBeforeSpawn();
        Patience.stopReaction = false;
        Patience.isPause = false;
    }

    public void SpawnSkelet()
    {
        int index;
        int i = UnityEngine.Random.Range(0, 100);
        if (i <= chanceOfChild && SetGetInfo.currentLevel > 2)
        {
            index = SpawnChild();
            isChild = true;
        }
        else
        {
            do
            {
                index = UnityEngine.Random.Range(0, skeletPrefab.Length);

            } while (index == SpawnChild());
        }
        float y = 129f;
        if (isChild)
        {
            y = 100f;
        }
        spawnPoint = new Vector2(spawnX, y);
        Instantiate(skeletPrefab[index], spawnPoint, Quaternion.identity).transform.SetParent(customer.transform);    
    }

    public void SpawnHats()
    {
        int i = UnityEngine.Random.Range(0, hats.Length);
        float y = 364.1f;
        if (isChild)
        {
            y = 336f;
        }
        spawnPoint = new Vector2(spawnX, y);
        Instantiate(hats[i], spawnPoint, Quaternion.identity).transform.SetParent(customer.transform);
    }

    public void SpawnFaces()
    {
        int i = UnityEngine.Random.Range(0, faces.Length);
        float y = 350.9f;
        if (isChild)
        {
            y = 323.5f;
        }
        spawnPoint = new Vector2(spawnX, y);
        Instantiate(faces[i], spawnPoint, Quaternion.identity).transform.SetParent(customer.transform);
    }

    public void SpawnFacesColor()
    {
        int i = UnityEngine.Random.Range(0, facesColor.Length);
        float y = 352.2f;
        if (isChild)
        {
            y = 325.1f;
        }
        spawnPoint = new Vector2(spawnX, y);
        Instantiate(facesColor[i], spawnPoint, Quaternion.identity).transform.SetParent(customer.transform);
    }

    public void SpawnTors()
    {
        int i = UnityEngine.Random.Range(0, tors.Length);
        float y = 115.8f;
        if (isChild)
        {
            y = 87.6f;
        }
        spawnPoint = new Vector2(spawnX, y);
        Instantiate(tors[i], spawnPoint, Quaternion.identity).transform.SetParent(customer.transform);
    }
}
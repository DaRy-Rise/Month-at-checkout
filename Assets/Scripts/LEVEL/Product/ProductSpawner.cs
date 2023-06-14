using System;
using UnityEngine;

public class ProductSpawner : MonoBehaviour
{
    private readonly float spawnX = 362f;
    private Vector2 spawnPoint;
    private static bool isFirst;
    private Product[] productPrefab;
    private GameObject lockerPrefab;
    public static int chanceOfGood;
    public static bool noProduct = true, isGood, haveAntiThief, alwaysAntiThief, turnOffAntiThief;
    public static Product product;  
    public static Action onSpawn;
    public static KindOfBarCode kindOffset;

    private void Start()
    {
        isFirst = true;
        SetChance();
        productPrefab = Resources.LoadAll<Product>("Prefab/ProductPrefab");
        lockerPrefab = Resources.Load<GameObject>("Prefab/ProductPrefab/Locker/Anti-thiefLocker");
        haveAntiThief = false;        
    }

    private void Update()
    {
        if (product == null && noProduct && GeneratorInfoCustomer.countOfProduct > 0 && CustomerSpawner.readyForProduct)
        {          
            noProduct = false;
            Spawn();
        }
    }
  
    private void GetQuality()
    {
        if (SetGetInfo.currentLevel == 1)
        {
            isGood = true;
        }
        else if (SetGetInfo.currentLevel == 2 && isFirst)
        {
            isGood = false;
        }
        else
        {
            int i = UnityEngine.Random.Range(1, 100);
            if (i <= chanceOfGood)
            {
                isGood = true;
            }
            else
            {
                isGood = false;     
            }
        }
    }

    private void SetAntiThief()
    {
        if (SetGetInfo.currentLevel < 3)
        {
            turnOffAntiThief = true;
        }
        else if (SetGetInfo.currentLevel == 3 && isFirst)
        {
            haveAntiThief = true;
        }
        else if ((product.price > 50 && !turnOffAntiThief) || alwaysAntiThief)
        {
            haveAntiThief = true;
        }
        if (haveAntiThief)
        {
            SpawnLocker();
        }
    }
    private void SpawnLocker()
    {
        float x = UnityEngine.Random.Range(-0.099f, 0.091f); 
        float y = UnityEngine.Random.Range(0.607f, -0.468f); 
        Instantiate(lockerPrefab, new Vector2(x, y), Quaternion.identity).transform.SetParent(product.transform);
    }

    private void SetChance()
    {
        switch (kindOffset)
        {
            case KindOfBarCode.Default:
                chanceOfGood = 80;
                break;
            case KindOfBarCode.MoreBad:
                chanceOfGood = 40;
                break;
            case KindOfBarCode.MoreGood:
                chanceOfGood = 90;
                break;
            case KindOfBarCode.AllBad:
                chanceOfGood = 0;
                break;
            case KindOfBarCode.AllGood:
                chanceOfGood = 100;
                break;
            default:
                break;
        }
    }

    public void SetScannedTag()
    {
        product.tag = "ProductScanned";
    }

    public void Spawn()
    {
        haveAntiThief = false;
        GetQuality();
        int index = UnityEngine.Random.Range(0, productPrefab.Length);
        if (SetGetInfo.currentLevel == 3 && isFirst)
        {
            for (int j = 0; j < productPrefab.Length; j++)
            {
                if (productPrefab[j].price >= 50)
                {
                    index = j;
                }
            }
        }
        product = productPrefab[index];
        spawnPoint = new Vector2(spawnX, transform.position.y);
        SpriteRenderer sr = product.GetComponent<SpriteRenderer>();
        if (isGood)
        {
            sr.sprite = Resources.Load<Sprite>(product.pathGood);
        }
        else
        {
            sr.sprite = Resources.Load<Sprite>(product.pathBad);
        }
        onSpawn?.Invoke();
        product = Instantiate(productPrefab[index], spawnPoint, Quaternion.identity);
        SetAntiThief();
        isFirst = false;
        DeleteProduct.deleteProcess = false;
    }
}
using System;
using UnityEngine;

public class Product : MonoBehaviour
{
    private const float xMin = -20.6f, xMax = 307.7f, yMin = 120, yMax = 540.5f;
    private static ParsingJson reader;
    [HideInInspector]
    public bool toRestrict;
    public int id;
    public float price;   
    public string pathGood, pathBad;
    public bool isAlcohol;
    public static Action onEndOfProducts;  

    private void Start()
    {
        reader = FindAnyObjectByType<ParsingJson>();
        SetName();
    }

    private void FixedUpdate()
    {
        if (toRestrict && !Surface.isOff)
        {
            GetComponent<Rigidbody2D>().position = new Vector2(
                Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, xMin, xMax),
                Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, yMin, yMax));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DestroyTrigger"))
        {
            if (gameObject.tag != "ProductBought")
            {
                if (((CustomerSpawner.isChild && !isAlcohol) || !CustomerSpawner.isChild) && !DeleteProduct.deleteProcess)
                {
                    KarmaPoints.ShowPoints(PointsToKarma.Minus);
                    Karma.countWrongDeletedProduct++;
                }
            }
            ProductSpawner.noProduct = true;
            GeneratorInfoCustomer.countOfProduct -= 1;
            Destroy(gameObject, 0.5f);
            if (GeneratorInfoCustomer.countOfProduct == 0)
            {
                onEndOfProducts?.Invoke();
            }
        }
    }

    private void SetName()
    {
        string path;
        if (PlayerPrefs.GetInt("language", 0) == 0)
        {
            path = "Assets/Resources/Json/Rus/ProductsName.json";
        }
        else
        {
            path = "Assets/Resources/Json/Eng/ProductsName.json";
        }
        name = reader.GetInfo<ProductsName>(path).products[id].name;
    }
}
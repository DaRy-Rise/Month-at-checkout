using TMPro;
using UnityEngine;

public class ProductInfo : MonoBehaviour
{
    public TextMeshProUGUI textNameOfProduct, textPriceOfProduct;

    private void Start()
    {
        SetZero();
    }

    private void Update()
    {
        if (GeneratorInfoCustomer.doesPay == true)
        {
            DeleteAll();
        }
    }

    private void SetZero()
    {
        textNameOfProduct.text = "---";
        textPriceOfProduct.text = "0";
    }

    public void ShowInfo()
    {
        textNameOfProduct.text = ProductSpawner.product.name;
        textPriceOfProduct.text = ProductSpawner.product.price.ToString();
    }

    public void DeleteAll()
    {
        SetZero();
    }
}
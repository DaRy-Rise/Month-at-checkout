using System;
using UnityEngine;

public class DeleteProduct : MonoBehaviour
{
    private Product product;
    public static bool deleteProcess;
    public static Action onEndOfProductsToPay, onEndOfProductsToLeave, onClickDelete, onWrongDeleteAndLeave;

    public void Delete()
    {
        product = FindAnyObjectByType<Product>();
        if (product != null)
        {
            if (!deleteProcess)
            {
                deleteProcess = true;
                onClickDelete?.Invoke();
                ProductSpawner.product.toRestrict = false;
                GeneratorInfoCustomer.countOfProduct--;
                ProductSpawner.noProduct = true;
                if (CustomerSpawner.isChild)
                {
                    if (!product.isAlcohol)
                    {
                        Patience.Fine(10);
                        KarmaPoints.ShowPoints(PointsToKarma.Minus);
                        Karma.countWrongDeletedProduct++;
                    }
                }
                else
                {
                    Patience.Fine(10);
                    KarmaPoints.ShowPoints(PointsToKarma.Minus);
                    Karma.countWrongDeletedProduct++;
                }
                if (product.tag != "ProductScanned")
                {
                    if (GeneratorInfoCustomer.countOfProduct == 0)
                    {
                        if (CounterProductPrice.isZero)
                        {
                            if (Karma.countWrongDeletedProduct > 0)
                            {
                                onWrongDeleteAndLeave?.Invoke();
                            }
                            else
                            {
                                SetGetInfo.customers += 1;
                                onEndOfProductsToLeave?.Invoke();
                            }
                        }
                        else
                        {
                            onEndOfProductsToPay?.Invoke();
                        }
                    }
                }
            }         
        }     
    }
}
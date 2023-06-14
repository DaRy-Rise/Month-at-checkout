using UnityEngine;

public class Surface : MonoBehaviour
{
    public static bool isOff;

    private void OnEnable()
    {
        DeleteProduct.onClickDelete += SurfaceTurnOff;
        CustomerMove.onLeave += SurfaceTurnOff;
        ProductSpawner.onSpawn += SurfaceTurnOn;
        ClickCard.onClickCard += SurfaceTurnOn;
    }

    private void OnDisable()
    {
        DeleteProduct.onClickDelete -= SurfaceTurnOff;
        CustomerMove.onLeave -= SurfaceTurnOff;
        ProductSpawner.onSpawn -= SurfaceTurnOn;
        ClickCard.onClickCard -= SurfaceTurnOn;
    }

    private void SurfaceTurnOn()
    {
        isOff = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void SurfaceTurnOff()
    {
        isOff = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
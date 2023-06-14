using UnityEngine;

public class NewProductTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ProductScanned")
        {
            collision.tag = "ProductBought";           
        }      
    }
}
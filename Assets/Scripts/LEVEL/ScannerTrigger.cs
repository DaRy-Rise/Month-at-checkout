using UnityEngine;
public class ScannerTrigger : MonoBehaviour
{   
    [SerializeField]
    private AudioSource beepSound;
    [SerializeField]
    private GameObject kasaLight;
    [SerializeField]
    private CounterProductPrice counter;
    [SerializeField]
    private ProductSpawner productSpw;
    public ProductInfo productInfo;

    private void Start()
    {
        InvokeRepeating("TurnLightOff", 0, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Product" && ProductSpawner.isGood && !ProductSpawner.haveAntiThief && !ScreenErrorManager.isError)
        {
            Scan();        
        }
    }

    private void TurnLightOff()
    {
        kasaLight.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Scan()
    {
        productSpw.SetScannedTag();       
        kasaLight.GetComponent<SpriteRenderer>().enabled = true;
        beepSound.Play();
        productInfo.ShowInfo();
        counter.Plus(ProductSpawner.product.price);
        if (CustomerSpawner.isChild && ProductSpawner.product.isAlcohol)
        {
            Karma.numberOfSoldAlcoholToChild++;
            KarmaPoints.ShowPoints(PointsToKarma.Minus);
        }
    }
}

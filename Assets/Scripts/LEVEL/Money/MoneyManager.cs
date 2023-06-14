using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    private Money money;
    [HideInInspector]
    public Money moneyCopy;
    public AudioSource coinSound, cashSound;

    public void ShowMoney()
    {      
        moneyCopy = Instantiate(money, new Vector2(0,0), Quaternion.identity);
        if (moneyCopy.tag == "coin")
        {
            coinSound.Play();
        }
        else
        {
            cashSound.Play();
        }
    }  
}
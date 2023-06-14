using UnityEngine;

public class MoneyCase : MonoBehaviour
{
    public static bool isClosed;

    private void Start()
    {
        if (isClosed)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("MoneyCase/Opened_boxDebaf");
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("MoneyCase/Opened_box");
        }
    }
}
using System;
using UnityEngine;

public class AntiThief : MonoBehaviour
{
    [SerializeField]
    private AudioSource unlock;
    public static Action onTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ProductSpawner.haveAntiThief && collision.tag == "Product" && Magnet.isWork == true)
        {
            unlock.Play();
            ProductSpawner.haveAntiThief = false;
            Locker.unlock = true;
            onTrigger?.Invoke();
        }
    }
}
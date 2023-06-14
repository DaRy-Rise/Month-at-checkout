using System;
using UnityEngine;

public class CustomerMove : MonoBehaviour 
{
    private Animator animator;
    public static Action onLeave;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Check.onTearOff += Leave;
        DeleteProduct.onEndOfProductsToLeave += Leave;
        DeleteProduct.onWrongDeleteAndLeave += Leave;
        Patience.onEndOfPatience += Leave;
    }

    private void OnDisable()
    {
        Check.onTearOff -= Leave;
        DeleteProduct.onEndOfProductsToLeave -= Leave;
        DeleteProduct.onWrongDeleteAndLeave -= Leave;
        Patience.onEndOfPatience -= Leave;
    }

    public void MoveLeft()
    {
        animator.SetBool("leaving", true);
        Destroy(gameObject, 1.1f);
    }

    public void Leave()
    {
        Patience.stopReaction = true;
        animator.SetBool("leaving", true);
        CustomerSpawner.readyForProduct = false;
        ProductSpawner.product.toRestrict = false;
        Destroy(gameObject, 0.9f);
        onLeave?.Invoke();
    }
}
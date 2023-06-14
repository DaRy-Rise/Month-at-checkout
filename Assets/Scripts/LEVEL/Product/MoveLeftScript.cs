using UnityEngine;

public class MoveLeftScript : MonoBehaviour
{
    private Vector2 targetLeft = new Vector2(-56, 138);
    private Vector2 currentVelocity;
    private readonly float smoothTime = 0.5f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ProductScanned")
        {
            collision.tag = "ProductBought";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ProductScanned")
        {
            collision.tag = "ProductBought";
        }
        if (collision.tag == "ProductBought")
        {
            collision.transform.position = Vector2.SmoothDamp(collision.transform.position, targetLeft, ref currentVelocity, smoothTime);
            ProductSpawner.product.toRestrict = false;
            animator.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.enabled = false;
        if (collision.tag == "ProductBought")
        {
            collision.tag = "ProductScanned";
            ProductSpawner.product.toRestrict = true;
        }
    }
}
using UnityEngine;

public class MoveRightScript : MonoBehaviour
{
    private Vector2 targetRight = new Vector2(240, 138);
    private Vector2 currentVelocity;
    private const float smoothTime = 0.5f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Product" || collision.tag == "ProductBought")
        {
            collision.transform.position = Vector2.SmoothDamp(collision.transform.position, targetRight, ref currentVelocity, smoothTime);
            ProductSpawner.product.toRestrict = false;
            animator.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Product" || collision.tag == "ProductBought" || collision.tag == "ProductScanned")
        {
            ProductSpawner.product.toRestrict = true;
            animator.enabled = false;
        }
    }
}
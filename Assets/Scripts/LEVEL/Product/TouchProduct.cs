using UnityEngine;

public class TouchProduct : MonoBehaviour
{
    private bool Drag;
    private Rigidbody2D rb;
    public static bool isPause;

    private void Start()
    {
        isPause = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        rb.gravityScale = 0;
        Drag = true;
    }

    private void OnMouseUp()
    {
        rb.gravityScale = 100;
        Drag = false;
    }

    private void FixedUpdate()
    {
        if (!isPause)
        {
            if (Drag)
            {
                Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(MousePos);
            }
        }
    }
}

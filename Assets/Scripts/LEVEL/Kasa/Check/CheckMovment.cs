using UnityEngine;

public class CheckMovment : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Check.onTearOff += Move;
    }

    private void OnDisable()
    {
        Check.onTearOff -= Move;
    }

    private void Move()
    {
        animator.SetBool("toMove", true);
        Destroy(gameObject, 0.6f);
    }
}
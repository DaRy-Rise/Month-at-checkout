using UnityEngine;

public class Signature : MonoBehaviour
{
    [SerializeField]
    private AudioSource penSound;
    private Animator animator;
   
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnBecameVisible()
    {
        penSound.Play();
        animator.SetBool("IsVisible", true);
    }
}
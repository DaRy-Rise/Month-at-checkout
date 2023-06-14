using UnityEngine;

public class Locker : MonoBehaviour
{
    private Animator animator;
    public static bool unlock;
    
    private void Start()
    {
        unlock = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (unlock)
        {
            Drop();
        }          
    }

    public void Drop()
    {
        animator.SetBool("unlock", true);
        Destroy(gameObject, 0.9f);
    }
}
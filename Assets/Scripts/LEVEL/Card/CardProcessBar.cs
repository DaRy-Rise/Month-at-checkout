using System;
using UnityEngine;

public class CardProcessBar : MonoBehaviour
{
    private Animator animator;
    [HideInInspector]
    public static float maxSpeed, minSpeed;
    public static Action onEndProcess;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        CardHoldTrigger.onProcess += Process;
    }

    private void OnDisable()
    {

        CardHoldTrigger.onProcess -= Process;
    }

    private void Process()
    {
        float i = UnityEngine.Random.Range(0.5f, 1);
        animator.speed = i;
    }

    public void EndProcess()
    {
        onEndProcess?.Invoke();
    }
}
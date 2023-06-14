using UnityEngine;
using System;

public class BagOnMainWindow : MonoBehaviour
{
    private int stage = 1;
    private Animator animator;
    public static Action onLastStage; 

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PanelBagSwipeDetectorOpenBag.onSwipe += ChangeStageOpenBag;
    }

    private void OnDisable()
    {
        PanelBagSwipeDetectorOpenBag.onSwipe -= ChangeStageOpenBag;
    }

    private void DeleteBag()
    {
        Destroy(gameObject, 0.45f);
    }

    public void ChangeStageOpenBag()
    {
        if (stage < 4)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"Prefab/BagPrefab/ShopBag{stage}");
            if (stage == 3)
            {
                BagManager.isBag = false;
                onLastStage?.Invoke();
                animator.SetBool("toGoToCustomer", true);
                DeleteBag();
            }
        }
        stage++;
    }
}
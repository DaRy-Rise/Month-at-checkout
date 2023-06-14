using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelBagSwipeDetector : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField]
    private AudioSource bagShowSound;
    private BagOnMainWindow bagPrefab;
    public static Action onSwipe;

    private void Start()
    {
        bagPrefab = Resources.Load<BagOnMainWindow>("Prefab/BagPrefab/BagOnMainWindow");
    }

    private void OnSwipeUp()
    {
        Instantiate(bagPrefab, new Vector2(237, -98), Quaternion.identity);
        bagShowSound.Play();
        onSwipe?.Invoke();
        gameObject.SetActive(false);
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.delta;
        if (delta.y > 0)
        {
            OnSwipeUp();
        }
    }

    public void OnDrag(PointerEventData eventData) { }
}

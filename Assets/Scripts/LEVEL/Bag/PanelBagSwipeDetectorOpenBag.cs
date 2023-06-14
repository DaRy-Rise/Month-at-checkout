using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelBagSwipeDetectorOpenBag : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField]
    private AudioSource bagSwipeSound;
    public static Action onSwipe;

    private void OnSwipeDown()
    {
        bagSwipeSound.Play();
        onSwipe?.Invoke();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.delta;
        if (delta.y <= 0)
        {
            OnSwipeDown();
        }
    }

    public void OnDrag(PointerEventData eventData) { }
}

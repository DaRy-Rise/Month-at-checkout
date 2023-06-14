using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckMainWindowSwipeDetector : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public static Action onSwipe;

    private void OnSwipeUp()
    {
        onSwipe?.Invoke();
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
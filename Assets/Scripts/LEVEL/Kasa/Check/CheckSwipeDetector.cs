using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckSwipeDetector : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField]
    private AudioSource swipeSound;
    public static Action onSwipe;

    private void OnSwipeDown()
	{
        if (PlayerPrefs.GetInt("music") == 1)
            swipeSound.Play();
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
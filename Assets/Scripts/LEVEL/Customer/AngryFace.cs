using UnityEngine;

public class AngryFace : MonoBehaviour
{
    [SerializeField]
    private GameObject numpad;
    private SpriteRenderer spriteRenderer;
    public static bool isCalmLeave;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    private void OnEnable()
    {
        Patience.onEndOfPatience += ShowAngryFace;
        DeleteProduct.onWrongDeleteAndLeave += ShowAngryFace;
        ConfirmPay.onPickWrongChange += ShowAngryFace;
    }

    private void OnDisable()
    {
        Patience.onEndOfPatience -= ShowAngryFace;
        DeleteProduct.onWrongDeleteAndLeave -= ShowAngryFace;
        ConfirmPay.onPickWrongChange -= ShowAngryFace;
    }

    private void ShowAngryFace()
    {
        numpad.SetActive(false);
        spriteRenderer.enabled = true;
        Invoke("TurnAngryFaceOff", 0.9f);
    }

    private void TurnAngryFaceOff()
    {
        spriteRenderer.enabled = false;
    }
}
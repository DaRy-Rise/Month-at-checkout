using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField]
    private float nominal;
    private Change payment;
    private GameObject coinBackSound, cashBackSound;
    private AudioSource coinBackSoundSource, cashBackSoundSource;
    private Animator animator;

    private void Start()
    {
        SetFields();
        payment.SetChange(nominal);
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ConfirmPay.onConfirm += MoveToCustomer;
    }

    private void OnDisable()
    {
        ConfirmPay.onConfirm -= MoveToCustomer;
    }

    private void OnMouseDown()
    {
        payment.MinusChange(nominal);
        MoveDown();
    }

    private void SetFields()
    {
        coinBackSound = GameObject.FindWithTag("coinBack");
        coinBackSoundSource = coinBackSound.GetComponent<AudioSource>();
        cashBackSound = GameObject.FindWithTag("cashBack");
        cashBackSoundSource = cashBackSound.GetComponent<AudioSource>();
        payment = FindObjectOfType<Change>();
    }

    public void MoveDown()
    {
        animator.SetBool("toGoDown", true);
        if (gameObject.tag == "coin")
        {
            coinBackSoundSource.Play();
        }
        else
        {
            cashBackSoundSource.Play();
        }
        Destroy(gameObject, 0.1f);
    }

    public void MoveToCustomer()
    {
        animator.SetBool("toEnd", true);
        Destroy(gameObject, 0.45f);
    }
}
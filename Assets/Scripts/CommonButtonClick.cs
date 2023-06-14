using UnityEngine;

public class CommonButtonClick : MonoBehaviour
{
    [SerializeField]
    private AudioSource click;

    public void Click()
    {
        click.Play();
    }
}

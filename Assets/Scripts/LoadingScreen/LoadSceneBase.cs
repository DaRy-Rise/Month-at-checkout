using System.Collections;
using UnityEngine;

public class LoadSceneBase : MonoBehaviour
{
    [SerializeField]
    private protected GameObject backGround;
    private protected AsyncOperation loadAsync;

    private void Start()
    {
        backGround.SetActive(false);
    }

    private IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = this.loadAsync;
        loadAsync.allowSceneActivation = false;
        while (!loadAsync.isDone)
        {
            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;

            }
            yield return null;
        }
    }

    public void Loading()
    {
        backGround.SetActive(true);

        StartCoroutine(LoadAsync());
    }
}

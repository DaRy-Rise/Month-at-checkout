using UnityEngine.SceneManagement;

public class LoadSceneAfterToCalendar : LoadSceneBase
{
    private void OnEnable()
    {
        Continue.onClickContinue += SetLoadAsync;
        Continue.onClickContinue += Loading;
    }

    private void OnDisable()
    {
        Continue.onClickContinue -= SetLoadAsync;
        Continue.onClickContinue -= Loading;
    }

    private void SetLoadAsync()
    {
        loadAsync = SceneManager.LoadSceneAsync(1);
    }
}
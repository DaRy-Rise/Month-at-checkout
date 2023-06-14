using UnityEngine.SceneManagement;

public class LoadSceneCardToLevel : LoadSceneBase
{
    private void OnEnable()
    {
        StartGame.onClickStart += SetLoadAsync;
        StartGame.onClickStart += Loading;
    }

    private void OnDisable()
    {
        StartGame.onClickStart -= SetLoadAsync;
        StartGame.onClickStart -= Loading;
    }

    private void SetLoadAsync()
    {
        loadAsync = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
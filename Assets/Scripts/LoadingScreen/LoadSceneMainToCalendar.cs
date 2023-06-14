using UnityEngine.SceneManagement;

public class LoadSceneMainToCalendar : LoadSceneBase
{
    private void OnEnable()
    {
        MainMenuBtns.onStartGame += SetLoadAsync;
        MainMenuBtns.onStartGame += Loading;
    }
    private void OnDisable()
    {
        MainMenuBtns.onStartGame += SetLoadAsync;
        MainMenuBtns.onStartGame -= Loading;
    }

    private void SetLoadAsync()
    {
        loadAsync = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
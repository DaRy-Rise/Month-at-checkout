using UnityEngine.SceneManagement;

public class LoadSceneCalendarToCard : LoadSceneBase
{
    private void OnEnable()
    {
        ChooseDay.onChooseDay += SetLoadAsync;
        ChooseDay.onChooseDay += Loading;
    }

    private void OnDisable()
    {
        ChooseDay.onChooseDay -= SetLoadAsync;
        ChooseDay.onChooseDay -= Loading;
    }

    private void SetLoadAsync()
    {     
        loadAsync = SceneManager.LoadSceneAsync(ChooseNextScene());
    }

    private static int ChooseNextScene()
    {
        if (SetGetInfo.currentLevel == 1)
        {
            return SceneManager.GetActiveScene().buildIndex + 2;
        }
        else
        {
           return SceneManager.GetActiveScene().buildIndex + 1;
        }
    }
}
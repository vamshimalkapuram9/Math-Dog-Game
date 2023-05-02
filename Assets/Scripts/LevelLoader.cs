using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int homePageIndex = 0;

    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void GoToHomePage()
    {
        SceneManager.LoadScene(homePageIndex);
    }

    public void subPractice()
    {
        SceneManager.LoadScene("Sub-Practice-Levels");
    }

    public void subBegin()
    {
        SceneManager.LoadScene("Sub-Begin");

    }

    
}

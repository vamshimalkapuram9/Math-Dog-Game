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

    
}

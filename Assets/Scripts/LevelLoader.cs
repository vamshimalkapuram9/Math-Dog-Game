using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
   private int homeScreenIndex = 1;

    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void GoToHomeScreen()
    {
        SceneManager.LoadScene(homeScreenIndex);
    }
}

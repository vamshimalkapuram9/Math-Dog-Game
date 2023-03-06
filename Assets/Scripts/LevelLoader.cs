using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This is going to be used to load all levels
 */

public class LevelLoader : MonoBehaviour
{



    public void LoadHomeScreen (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    //This function is to just create a loading bar for splash screen to home screen
    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            //The following float is just for the loading to go from 0 to 1.
            float progress = Mathf.Clamp01(operation/.9f);

            yield return null;
        }
    }


    public void LoadPuzzleLevel(int sceneIndex)
    {

    }


    public void LoadFunLevel(int sceneIndex)
    {
    }

    public void LoadQuizLevel(int sceneIndex)
    {
    }

    public void LoadPracticeLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }

    public void LoadBeginnerLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadIntermediateLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }


    public void NavigateToPreviousScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}

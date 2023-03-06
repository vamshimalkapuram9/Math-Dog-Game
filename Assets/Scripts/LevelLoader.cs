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
            yield return null;
        }
    }
    
}

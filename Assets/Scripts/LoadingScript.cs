using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    [SerializeField]
    public GameObject loadingPanel;
    public Slider loadingSlider;
    // public Text progressText;
    public void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }


    IEnumerator LoadAsyncOperation()
    {
        yield return new WaitForSeconds(3);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync("HomeScreen");
        loadingPanel.SetActive(true);

        while (!gameLevel.isDone)
        {
            float progress = Mathf.Clamp01(gameLevel.progress / .9f);
            // progressText.text = progress * 100 + "%";
            loadingSlider.value = progress;

            yield return null;
        }

    }
}
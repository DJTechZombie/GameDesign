using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject loadScreen;
    public Slider loadSlider;

    public void LoadNextLevel()
    {
        StartCoroutine(loadAsync(1));
    }

    public void LoadPursuit()
    {
        StartCoroutine(loadAsync(2));
    }

    public void LoadCarSelect ()
    {
        StartCoroutine(loadAsync(3));
    }

    IEnumerator loadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadSlider.value = progress;
            yield return null;
        }
    }
}

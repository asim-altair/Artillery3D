using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;

    public void LoadScene(string name)
    {
        StartCoroutine(LoadSceneAsync(name));
    }

    IEnumerator LoadSceneAsync(string name)
    {
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        operation.allowSceneActivation = false;

        while(operation.progress < 0.9f)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
        loadingBar.value = 1f;

        yield return new WaitForSeconds(1);
        operation.allowSceneActivation = true;
    }
}

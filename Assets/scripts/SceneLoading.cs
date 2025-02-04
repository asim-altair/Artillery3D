using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;

    public string[] missions;


    public void LoadScene(string name)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadSceneAsync(name));
    }

    public void LoadMission()
    {
        string name = missions[Player.Instance.selectedMission];
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

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void RestartScene()
    {
        string name = SceneManager.GetActiveScene().name;
        Time.timeScale = 1;
        StartCoroutine(LoadSceneAsync(name));
    }
}

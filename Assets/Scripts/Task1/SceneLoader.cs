using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private GameObject progressBar;
    [SerializeField] private Image progressBarLine;
    [SerializeField] private TMP_Text loadingText;
    private AsyncOperation asyncOperation;
    

    public static void DefaultLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void AsyncLoad(string nextSceneName)
    {
        StartCoroutine("AsyncLoadCOR");
    }

    private IEnumerator AsyncLoadCOR()
    {
        
        float loadingProgress;
        asyncOperation = SceneManager.LoadSceneAsync(nextSceneName);
        progressBar.SetActive(true);
        while (!asyncOperation.isDone)
        {
            loadingProgress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            loadingText.text = $"Загрузка ... {(loadingProgress * 100f).ToString("0")}%";
            progressBarLine.fillAmount = loadingProgress;
            yield return null;
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private Slider loadingBar;
    public void OpenLevel(string scene)
    {
        StartCoroutine(LoadAsync(scene));
    }
    public void OpenLevel(int index)
    {
        StartCoroutine(LoadAsync(index));
    }
    private IEnumerator LoadAsync(string scene)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(scene);
        if (op == null)
        {
            yield break;
        }
        if (loadingBar != null)
        {
            loadingBar.value = 0;
        }
        if (transition != null)
        {
            transition.SetTrigger("Start");
        }
        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);
            loadingBar.value = progress;
            yield return null;
        }
    }
    private IEnumerator LoadAsync(int index)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(index);
        if (op == null)
        {
            yield break;
        }
        if (loadingBar != null)
        {
            loadingBar.value = 0;
        }
        if (transition != null)
        {
            transition.SetTrigger("Start");
        }
        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);
            loadingBar.value = progress;
            yield return null;
        }
    }
}

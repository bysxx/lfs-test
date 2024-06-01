using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : DontDestroySingleton<SceneManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    // 씬을 비동기로 로드하는 메서드
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // 특정 시간 후에 씬을 로드하는 메서드
    public void LoadScene(string sceneName, float delay)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName, delay));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        yield return LoadSceneAsync(sceneName);
    }

    // 현재 씬의 이름을 반환하는 메서드
    public string GetCurrentSceneName()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
}

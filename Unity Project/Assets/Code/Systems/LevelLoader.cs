using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public FloatVariable levelLoadingProgress;
    public StringVariable sceneName;

    private void OnEnable()
    {
        levelLoadingProgress.Reset();
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelAsync(sceneName.CurrentValue));
    }

    private IEnumerator LoadLevelAsync(string sceneName)
    {
        var operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            levelLoadingProgress.CurrentValue = Mathf.Clamp01(operation.progress / 0.9f);

            yield return null;
        }
    }
}

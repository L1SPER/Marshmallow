using UnityEngine;
public class SceneButtonHandler : MonoBehaviour
{
    public void LoadSceneAsyncByName(string sceneName)
    {
        SceneLoaderManager.Instance.LoadSceneAsync(sceneName);
    }

    public void LoadSceneAsyncById(int sceneId)
    {
        SceneLoaderManager.Instance.LoadSceneAsync(sceneId);
    }

    public void LoadScene(string sceneName) 
    {
        SceneLoaderManager.Instance.LoadScene(sceneName);
    }

    public void LoadScene(int sceneId) 
    {
        SceneLoaderManager.Instance.LoadScene(sceneId);
    }
    
}

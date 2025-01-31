using UnityEngine;
public class SceneButtonHandler : MonoBehaviour
{
    public void LoadSceneAsyncByName(string sceneName)
    {
        ManagerHub.Instance.GetManager<SceneLoaderManager>().LoadSceneAsync(sceneName);
    }
    public void LoadSceneAsyncById(int sceneId)
    {
        ManagerHub.Instance.GetManager<SceneLoaderManager>().LoadSceneAsync(sceneId);
    }

    public void LoadScene(string sceneName)
    {
        ManagerHub.Instance.GetManager<SceneLoaderManager>().LoadScene(sceneName);
    }

    public void LoadScene(int sceneId)
    {
        ManagerHub.Instance.GetManager<SceneLoaderManager>().LoadScene(sceneId);
    }
}

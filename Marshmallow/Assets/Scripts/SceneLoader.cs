using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    private Stack<string> sceneHistory =new Stack<string>();
    private string currentSceneName;
    
    private void Awake()
    {
        ManagerHub.Instance.RegisterManager(this);
        currentSceneName=SceneManager.GetActiveScene().name;
        sceneHistory.Push(currentSceneName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded+=OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded-= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneName =scene.name;
        if(!sceneHistory.Contains(currentSceneName))
        {
            sceneHistory.Push(currentSceneName);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void LoadSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadSceneAsync(int sceneId)
    {
        SceneManager.LoadSceneAsync(sceneId);
    }

    public void GoBack()
    {
        if(sceneHistory.Count>1)
        {
            sceneHistory.Pop();
            string previousScene= sceneHistory.Peek();
            LoadScene(previousScene);
        }
        else
        {
            Debug.Log("No previous scene to return to!");
        }
    }
}

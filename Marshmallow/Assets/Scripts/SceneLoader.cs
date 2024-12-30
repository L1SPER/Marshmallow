using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager: MonoBehaviour
{
    private static SceneLoaderManager instance;
    public static SceneLoaderManager Instance { get => instance; private set=> instance=value; }
    
    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (Instance != null&&  Instance!=this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void LoadSceneAsync(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
    
    public void LoadSceneAsync(int sceneId)
    {
        SceneManager.LoadSceneAsync(sceneId);
    }
}

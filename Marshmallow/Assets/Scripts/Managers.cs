using UnityEngine;
public class Managers : MonoBehaviour
{
    static Managers instance;
    public static Managers Instance { get => instance; private set => instance = value; }

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
        DontDestroyOnLoad(gameObject);
    }
    

}

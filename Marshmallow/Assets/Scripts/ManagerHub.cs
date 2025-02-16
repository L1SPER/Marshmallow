using System.Collections.Generic;
using UnityEngine;

public class ManagerHub : MonoBehaviour
{
    public static ManagerHub Instance { get; private set; }
    private Dictionary<System.Type, MonoBehaviour> managers = new Dictionary<System.Type, MonoBehaviour>();

    private void Awake()
    {
        if(Instance!=null&&Instance!=this)
        {
            Destroy(gameObject);
            return;
        }
        Instance=this;
        DontDestroyOnLoad(Instance);
    }

    //Registers manager
    public void RegisterManager<T>(T  manager) where T:  MonoBehaviour
    {
        var type= typeof(T);
        if(!managers.ContainsKey(type))
        {
            managers[type]=manager;                
        }
    }

    //Gets manager
    public T GetManager<T>() where T: MonoBehaviour
    {
        var type = typeof(T);
        if(managers.ContainsKey(type))
        {
            return managers[type] as T;
        }

        Debug.LogError($"Manager of type {type.Name} is not registered!");
        return null;
    }
}

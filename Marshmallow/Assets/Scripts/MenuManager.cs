using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static Dictionary<MenuType,GameObject> menusDictionary = new Dictionary<MenuType, GameObject>();

    private void Awake()
    {
        ManagerHub.Instance.RegisterManager(this);
    }

    /// <summary>
    /// Adds menu type with gameObject to dictionary
    /// </summary>
    /// <param name="menuType"></param>
    /// <param name="gameObject"></param>
    public void AddToMenus(MenuType menuType,  GameObject gameObject)
    {
        if (!menusDictionary.ContainsKey(menuType))
        {
            menusDictionary.Add(menuType, gameObject);
            //Debug.Log($"Menü eklendi: {gameObject.name}");
        }
        else
        {
            Debug.LogWarning($"Menü zaten mevcut: {gameObject.name}");
        }
    }

    /// <summary>
    /// Removes menu type from dictionary
    /// </summary>
    /// <param name="menuType"></param>
    public void RemoveFromMenus(MenuType menuType)
    {
        if (menusDictionary.ContainsKey(menuType))
        {
            menusDictionary.Remove(menuType);
        }
        else
        {
            Debug.LogWarning("There is not a gameObject to remove !!!");
        }
    }

    /// <summary>
    /// Checks if dictionary contains that menu type
    /// </summary>
    /// <param name="menuType"></param>
    /// <returns></returns>
    public bool ContainsMenuType(MenuType menuType)
    {
        return menusDictionary.ContainsKey(menuType);
    }

    /// <summary>
    /// Checks if dictionary contains that gameObject
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public bool ContainsMenu(GameObject gameObject)
    {
        return menusDictionary.ContainsValue(gameObject);
    }

    /// <summary>
    /// Finds first menu type that matches gameObject in dictionary
    /// </summary>
    /// <param name="menuType"></param>
    /// <returns></returns>
    public MenuType? FindMenuTypeByGameObjectInDictionary(GameObject gameObject)
    {
        foreach (var item in menusDictionary)
        {
            if (item.Value == gameObject)
            {
                return item.Key;
            }
        }
        return null;
    }

    /// <summary>
    /// Finds gameObject that matches menu type in dictionary
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public GameObject FindGameObjectInDictionary(MenuType menuType)
    {
        return menusDictionary.ContainsKey(menuType) ? menusDictionary[menuType] : null;
    }

    /// <summary>
    /// Deletes all menus in dictionary
    /// </summary>
    public void DeleteMenusDictionary()
    {
        menusDictionary.Clear();
    }
    
}
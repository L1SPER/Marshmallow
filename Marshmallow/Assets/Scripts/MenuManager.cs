using System.Collections.Generic;
using UnityEngine;

public enum MenuType
{
    None,
    Main,
    Settings,
    Statistics,
    Quit
}
public class MenuManager : MonoBehaviour
{
    #region Variables Section
    [Header("Menus")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject statisticsMenu;
    [SerializeField] GameObject quitMenu;
    #endregion
    public static Dictionary<GameObject, MenuType> menusDictionary = new Dictionary<GameObject, MenuType>();
    private void Awake()
    {
        ManagerHub.Instance.RegisterManager(this);
    }
    private void Start()
    {
        HideMenus();
        mainMenu.GetComponent<ArrowNavigation>().SetInitialButton();
    }

    private void HideMenus()
    {
        HideMenu(settingsMenu);
        HideMenu(statisticsMenu);
        HideMenu(quitMenu);
    }
   
     private void ShowMenu(GameObject menu)
    {
        if (!ContainsMenu(menu))
        {
            Debug.LogError("Menus dictionary dont contains menu");
            return;
        }
        menu.SetActive(true);
        StartCoroutine(menu.GetComponent<ArrowNavigation>().SetButtonNextFrame(menu.GetComponent<ArrowNavigation>().buttons[0].gameObject));
    }
    public void SwitchMenu(GameObject fromMenu, GameObject toMenu)
    {
        HideMenu(fromMenu);
        ShowMenu(toMenu);
    }
    public void HideMenu(GameObject menu)
    {
        menu.SetActive(false);
    }
    public void HideMenu(MenuType menuType)
    {
        GameObject menu = FindGameObjectByMenuTypeInDictionary(menuType);
        if (menu != null)
        {
            menu.SetActive(false);
        }
    }
    public void OpenOptionsMenu()
    {
        SwitchMenu(mainMenu, settingsMenu);
    }
    public void CloseOptionsMenu()
    {
        SwitchMenu(settingsMenu, mainMenu);
    }
    public void OpenStatisticsMenu()
    {
        SwitchMenu(mainMenu, statisticsMenu);
    }
    public void CloseStatisticsMenu()
    {
        SwitchMenu(statisticsMenu, mainMenu);
    }
    public void OpenQuitMenu()
    {
        SwitchMenu(mainMenu, quitMenu);
    }
    public void CloseQuitMenu()
    {
        SwitchMenu(quitMenu, mainMenu);
    }
    public void OpenChapter1()
    {
        //HideMenu(mainMenu);
        ManagerHub.Instance.GetManager<SceneLoaderManager>().LoadScene("Chapter1");

        //StartCoroutine(menu.GetComponent<ArrowNavigation>().SetButtonNextFrame(menu.GetComponent<ArrowNavigation>().buttons[0].gameObject));

        //Chapter 1 acilacak
    }
    /// <summary>
    /// Adds gameObject with menu type to dictionary
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="menuType"></param>
    public void AddToMenus(GameObject gameObject, MenuType menuType)
    {
        if (!menusDictionary.ContainsKey(gameObject))
        {
            menusDictionary.Add(gameObject, menuType);
            //Debug.Log($"Menü eklendi: {gameObject.name}");
        }
        else
        {
            Debug.LogWarning($"Menü zaten mevcut: {gameObject.name}");
        }
    }
    /// <summary>
    /// Removes gameObject from dictionary
    /// </summary>
    /// <param name="gameObject"></param>
    public void RemoveFromMenus(GameObject gameObject)
    {
        if (menusDictionary.ContainsKey(gameObject))
        {
            menusDictionary.Remove(gameObject);
        }
        else
        {
            Debug.LogWarning("There is not a gameObject to remove !!!");
        }
    }
    /// <summary>
    /// Checks if dictionary contains same gameObject
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public bool ContainsMenu(GameObject gameObject)
    {
        return menusDictionary.ContainsKey(gameObject);
    }
    /// <summary>
    /// Checks if dictionary contains same menu type
    /// </summary>
    /// <param name="menuType"></param>
    /// <returns></returns>
    public bool ContainsMenuType(MenuType menuType)
    {
        return menusDictionary.ContainsValue(menuType);
    }
    /// <summary>
    /// Finds first gameObject that matches menu type in dictionary
    /// </summary>
    /// <param name="menuType"></param>
    /// <returns></returns>
    private GameObject  FindGameObjectByMenuTypeInDictionary(MenuType menuType)
    {
        foreach (var m in menusDictionary)
        {
            if (m.Value == menuType)
            {
                return m.Key;
            }
        }
        return null;
    }
    /// <summary>
    /// Finds menu type of gameObject in dictionary
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    private MenuType? FindMenuTypeInDictionary(GameObject gameObject)
    {
        return menusDictionary.TryGetValue(gameObject, out MenuType menuType) ?  menuType:  null; 
    }
    /// <summary>
    /// Deletes all menus in dictionary
    /// </summary>
    public void DeleteMenusDictionary()
    {
        menusDictionary.Clear();
    }
    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}

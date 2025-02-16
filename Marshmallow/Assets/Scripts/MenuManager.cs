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
    public static Dictionary<GameObject, MenuType> menus = new Dictionary<GameObject, MenuType>();
    private void Awake()
    {
        ManagerHub.Instance.RegisterManager(this);
    }
    private void Start()
    {
        HideMenus();
        Debug.Log("Count : " + menus.Count);
        PrintMenuDictionary();

        mainMenu.GetComponent<ArrowNavigation>().SetInitialButton();
    }

    private void HideMenus()
    {
        HideMenu(settingsMenu);
        HideMenu(statisticsMenu);
        HideMenu(quitMenu);
    }

    private void PrintMenuDictionary()
    {
        foreach (var m in menus)
        {
            Debug.Log("M.Key Name : " + m.Key.name);
        }
    }
     private void ShowMenu(GameObject menu)
    {
        if (!ContainsMenu(menu))
        {
            Debug.LogError("Menus dictionary dont contains menu");
            return;
        }
        menu.SetActive(true);
        //StartCoroutine(menu.GetComponent<ArrowNavigation>().SetButtonNextFrame(menu.transform.GetChild(0).gameObject));
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
        HideMenu(mainMenu);
        //Chapter 1 acilacak
    }
    public void AddToMenus(GameObject gameObject, MenuType menuType)
    {
        if (!menus.ContainsKey(gameObject))
        {
            menus.Add(gameObject, menuType);
            //Debug.Log($"Menü eklendi: {gameObject.name}");
        }
        else
        {
            Debug.LogWarning($"Menü zaten mevcut: {gameObject.name}");
        }
    }
    public void RemoveFromMenus(GameObject gameObject)
    {
        if (menus.ContainsKey(gameObject))
        {
            menus.Remove(gameObject);
        }
        else
        {
            Debug.LogWarning("There is not a gameObject to remove !!!");
        }
    }
    public bool ContainsMenu(GameObject gameObject)
    {
        return menus.ContainsKey(gameObject);
    }
    public bool ContainsMenuType(MenuType menuType)
    {
        return menus.ContainsValue(menuType);
    }
    public void DeleteMenusDictionary()
    {
        menus.Clear();
    }
    private GameObject FindGameObjectInDictionary(MenuType menuType)
    {
        foreach (var m in menus)
        {
            if (m.Value == menuType)
            {
                return m.Key;
            }
        }
        return null;
    }
    private GameObject FindGameObjectInDictionary(GameObject gameObject)
    {
        foreach (var m in menus)
        {
            if (m.Key == gameObject)
            {
                return m.Key;
            }
        }
        return null;
    }
    private MenuType? FindMenuTypeInDictionary(GameObject gameObject)
    {
        foreach (var m in menus)
        {
            if (m.Key == gameObject)
            {
                return m.Value;
            }
        }
        return null;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

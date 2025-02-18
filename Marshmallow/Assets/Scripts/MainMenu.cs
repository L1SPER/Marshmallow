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
public class MainMenu : MonoBehaviour
{
    MenuManager menuManager;
    
    /// <summary>
    /// Finds the managers
    /// </summary>
    private void Awake()
    {
        menuManager= ManagerHub.Instance.GetManager<MenuManager>();
    }

    /// <summary>
    /// Sets initial button for main menu
    /// </summary>
    private void Start()
    {
        HideMenus();
        menuManager.FindGameObjectInDictionary(MenuType.Main).GetComponent<ArrowNavigation>().SetInitialButton();
    }

    /// <summary>
    /// Hides all menus in the beginning except main menu
    /// </summary>
    private void HideMenus()
    {
        HideMenu(MenuType.Settings);
        HideMenu(MenuType.Statistics);
        HideMenu(MenuType.Quit);
    }

    /// <summary>
    /// Shows the menu that matches the menu type
    /// </summary>
    /// <param name="menuType"></param>
    private void ShowMenu(MenuType menuType)
    {
        if (!menuManager.ContainsMenuType(menuType))
        {
            Debug.LogError("Menus dictionary doesnt contains menu");
            return;
        }
        menuManager.FindGameObjectInDictionary(menuType).SetActive(true);
        StartCoroutine(menuManager.FindGameObjectInDictionary(menuType).GetComponent<ArrowNavigation>().SetButtonNextFrame(menuManager.FindGameObjectInDictionary(menuType).GetComponent<ArrowNavigation>().buttons[0].gameObject));
    }

    /// <summary>
    /// Switches the menu from one to another
    /// </summary>
    /// <param name="fromMenu"></param>
    /// <param name="toMenu"></param>
    public void SwitchMenu(MenuType fromMenu, MenuType toMenu)
    {
        HideMenu(fromMenu);
        ShowMenu(toMenu);
    }

    /// <summary>
    /// Hides the menu that matches the menu type
    /// </summary>
    /// <param name="menuType"></param>
    public void HideMenu(MenuType menuType)
    {
        GameObject menu = menuManager.FindGameObjectInDictionary(menuType);
        if (menu != null)
        {
            menu.SetActive(false);
        }
    }

    /// <summary>
    /// Opens the options menu
    /// </summary>
    public void OpenOptionsMenu()
    {
        SwitchMenu( MenuType.Main,MenuType.Settings);
    }

    /// <summary>
    /// Closes the options menu
    /// </summary>
    public void CloseOptionsMenu()
    {
        SwitchMenu(MenuType.Settings,  MenuType.Main);
    }

    /// <summary>
    /// Opens the statistics menu
    /// </summary>
    public void OpenStatisticsMenu()
    {
        SwitchMenu( MenuType.Main, MenuType.Statistics);
    }

    /// <summary>
    /// Closes the statistics menu
    /// </summary>
    public void CloseStatisticsMenu()
    {
        SwitchMenu(MenuType.Statistics,  MenuType.Main);
    }

    /// <summary>
    /// Opens the quit menu
    /// </summary>
    public void OpenQuitMenu()
    {
        SwitchMenu( MenuType.Main, MenuType.Quit);
    }

    /// <summary>
    /// Closes the quit menu
    /// </summary>
    public void CloseQuitMenu()
    {
        SwitchMenu(MenuType.Quit,  MenuType.Main);
    }

    /// <summary>
    /// Opens the first chapter
    /// </summary>
    public void OpenChapter1()
    {
        ManagerHub.Instance.GetManager<SceneLoaderManager>().LoadScene("Chapter1");
    }
    
    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
    
}

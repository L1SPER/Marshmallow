using UnityEngine;

public enum MenuType
{
    None,
    Main,
    Settings,
    Statistics,
    Quit,
    Chapter1
}

public abstract class MenuBase : MonoBehaviour
{

    protected MenuManager menuManager;

    protected virtual void Start()
    {
        menuManager = ManagerHub.Instance.GetManager<MenuManager>();
    }

    protected abstract void HideMenus();

    /// <summary>
    /// Shows the menu that matches the menu type
    /// </summary>
    /// <param name="menuType"></param>
    protected void ShowMenu(MenuType menuType)
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
    protected void SwitchMenu(MenuType fromMenu, MenuType toMenu)
    {
        HideMenu(fromMenu);
        ShowMenu(toMenu);
    }

    /// <summary>
    /// Hides the menu that matches the menu type
    /// </summary>
    /// <param name="menuType"></param>
    protected void HideMenu(MenuType menuType)
    {
        GameObject menu = menuManager.FindGameObjectInDictionary(menuType);
        if(menuManager==null)
        {
            Debug.LogError("Menu manager not found");
            return;
        }
        if (menu != null)
        {
            menu.SetActive(false);
        }
        else
        {
            Debug.LogError("Menu not found in dictionary");
        }
    }

}

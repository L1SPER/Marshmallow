using UnityEngine;

public class MainMenu : MenuBase
{
    /// <summary>
    /// Sets initial button for main menu
    /// </summary>
    protected override void Start()
    {
        HideMenus();
        menuManager.FindGameObjectInDictionary(MenuType.Main).GetComponent<ArrowNavigation>().SetInitialButton();
    }

    /// <summary>
    /// Hides all menus in the beginning except main menu
    /// </summary>
    protected override void HideMenus()
    {
        HideMenu(MenuType.Settings);
        HideMenu(MenuType.Statistics);
        HideMenu(MenuType.Quit);
    }

    /// <summary>
    /// Opens the options menu
    /// </summary>
    public void OpenOptionsMenu() => SwitchMenu(MenuType.Main, MenuType.Settings);

    /// <summary>
    /// Closes the options menu
    /// </summary>
    public void CloseOptionsMenu() => SwitchMenu(MenuType.Settings, MenuType.Main);
    
    /// <summary>
    /// Opens the statistics menu
    /// </summary>
    public void OpenStatisticsMenu() => SwitchMenu(MenuType.Main, MenuType.Statistics);

    /// <summary>
    /// Closes the statistics menu
    /// </summary>
    public void ClosestatisticsMenu() => SwitchMenu(MenuType.Statistics, MenuType.Main);

    /// <summary>
    /// Opens the quit menu
    /// </summary>
    public void OpenQuitMenu() => SwitchMenu(MenuType.Main, MenuType.Quit);
   
    /// <summary>
    /// Closes the quit menu
    /// </summary>
    public void CloseQuitMenu() => SwitchMenu(MenuType.Quit,  MenuType.Main);
    
    /// <summary>
    /// Opens the first chapter
    /// </summary>
    public void OpenChapter1Menu()
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

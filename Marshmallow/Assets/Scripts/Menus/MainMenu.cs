using System;
using UnityEngine;

public class MainMenu : MenuBase
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject statisticsMenu;
    [SerializeField] private GameObject quitMenu;

    private void Start()
    {
        HideMenus();
        mainMenu.GetComponent<ArrowNavigation>().SetInitialButton();
    }
    protected override void HideMenus()
    {
        settingsMenu.SetActive(false);
        statisticsMenu.SetActive(false);
        quitMenu.SetActive(false);
    }

    protected override void ShowMenu(GameObject menu)
    {
        base.ShowMenu(menu);
    }
    public void OpenOptionsMenu() 
    {
        SwitchMenu(mainMenu, settingsMenu);
        settingsMenu.GetComponent<ArrowNavigation>().SetInitialButton();
    }
        
    public void CloseOptionsMenu() 
    {
        SwitchMenu(settingsMenu, mainMenu);
        mainMenu.GetComponent<ArrowNavigation>().SetInitialButton();
    }
    public void OpenStatisticsMenu()
    {
        SwitchMenu(mainMenu, statisticsMenu);
        statisticsMenu.GetComponent<ArrowNavigation>().SetInitialButton();
    }
    public void CloseStatisticsMenu() 
    {
        SwitchMenu(statisticsMenu, mainMenu);
        mainMenu.GetComponent<ArrowNavigation>().SetInitialButton();
    }
    public void OpenQuitMenu() 
    {
        SwitchMenu(mainMenu, quitMenu);
        quitMenu.GetComponent<ArrowNavigation>().SetInitialButton();
    }
    public void CloseQuitMenu()
    {
        SwitchMenu(quitMenu, mainMenu);
        mainMenu.GetComponent<ArrowNavigation>().SetInitialButton();
    }
    public void OpenChapter1Menu()
    {
        ManagerHub.Instance.GetManager<SceneLoaderManager>().LoadScene("Chapter1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}

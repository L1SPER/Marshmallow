using UnityEngine;

public abstract class MenuBase : MonoBehaviour
{
    protected abstract  void  HideMenus();
    protected virtual void  HideMenu(GameObject menu)
    {
        menu.SetActive(false);
    }
    protected virtual void  ShowMenu(GameObject menu)
    {
        menu.SetActive(true);
    }
    protected virtual void  SwitchMenu(GameObject fromMenu, GameObject toMenu)
    {
        HideMenu(fromMenu);
        ShowMenu(toMenu);
    }
    
}

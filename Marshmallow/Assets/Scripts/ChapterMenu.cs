using System;
using Unity.VisualScripting;
using UnityEngine;

public class ChapterMenu : MenuBase
{
    public void OpenMainMenu()
    {
        ManagerHub.Instance.GetManager<SceneLoaderManager>().LoadScene("MainMenu");
    }
    protected override void HideMenus()
    {
        //throw new NotImplementedException();
    }
}

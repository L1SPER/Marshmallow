using System;
using Unity.VisualScripting;
using UnityEngine;

public class ChapterMenu : MenuBase
{
    protected override void Start()
    {
        HideMenus();
        menuManager.FindGameObjectInDictionary(MenuType.Chapter1).GetComponent<ArrowNavigation>().SetInitialButton();
    }

    protected override void HideMenus()
    {

    }
}

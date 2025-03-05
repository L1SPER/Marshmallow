using System;
using Unity.VisualScripting;
using UnityEngine;

public class ChapterMenu : MenuBase
{
    [SerializeField] private GameObject chapter1Menu;

    private void Start()
    {
        chapter1Menu.GetComponent<ArrowNavigation>().SetInitialButton();
    }
    public void OpenMainMenu()
    {
        ManagerHub.Instance.GetManager<SceneLoaderManager>().LoadScene("MainMenu");
    }
    protected override void HideMenus()
    {
        //throw new NotImplementedException();
    }
}

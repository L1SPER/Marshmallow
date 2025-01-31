using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject statisticsMenu;

    private void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        statisticsMenu.SetActive(false);
        mainMenu.GetComponent<ArrowNavigation>().SetInitialButton();
    }
    public void OpenChapter1()
    {
        mainMenu.SetActive(false);
        //Chapter 1 acilacak
    }
    public void OpenOptionsMenu()
    {
        mainMenu.SetActive(false);
        StartCoroutine(settingsMenu.GetComponent<ArrowNavigation>().SetButtonNextFrame(settingsMenu.transform.GetChild(0).gameObject));
        settingsMenu.SetActive(true);
    }
    public void CloseOptionsMenu()
    {
        settingsMenu.SetActive(false);
        StartCoroutine(mainMenu.GetComponent<ArrowNavigation>().SetButtonNextFrame(mainMenu.transform.GetChild(0).gameObject));
        mainMenu.SetActive(true);
    }
    public void OpenStatisticsMenu()
    {
        mainMenu.SetActive(false);
        StartCoroutine(statisticsMenu.GetComponent<ArrowNavigation>().SetButtonNextFrame(statisticsMenu.transform.GetChild(0).gameObject));
        statisticsMenu.SetActive(true);
    }
    public void CloseStatisticsMenu()
    {
        statisticsMenu.gameObject.SetActive(false);
        StartCoroutine(mainMenu.GetComponent<ArrowNavigation>().SetButtonNextFrame(mainMenu.transform.GetChild(0).gameObject));
        mainMenu.SetActive(true);
    }
    /*  public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
       
        settingsMenu.SetActive(false);
        statisticsMenu.SetActive(false);
    } */
    public void QuitGame()
    {
        Application.Quit();
    }
}

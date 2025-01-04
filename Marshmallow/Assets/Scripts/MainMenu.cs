using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas mainMenu;
    [SerializeField] Canvas settingsMenu;
    GameObject settingsCanvas;
    ArrowNavigation arrowNavigation;
    private void Start()
    {
        settingsCanvas = GameObject.FindGameObjectWithTag("Canvasses");
        mainMenu.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        mainMenu.gameObject.SetActive(false);
    }

    public void OpenOptionsMenu()
    {
        mainMenu.gameObject.SetActive(false);
        settingsCanvas.transform.GetChild(1).GetComponent<ArrowNavigation>().ResetCurrentIndex();
        settingsCanvas.transform.GetChild(1).GetComponent<ArrowNavigation>().UpdateArrowPosition(0);
        settingsMenu.gameObject.SetActive(true);
    }
    public void CloseOptionsMenu()
    {
        settingsMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
    public void OpenStatisticsMenu()
    {
        mainMenu.gameObject.SetActive(false);
        //statisticsMenu.gameObject.SetActive(true);
    }
    public void CloseStatisticsMenu()
    {
        //statisticsMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
    public void OpenMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        settingsCanvas.transform.GetChild(0).GetComponent<ArrowNavigation>().ResetCurrentIndex();
        settingsCanvas.transform.GetChild(0).GetComponent<ArrowNavigation>().UpdateArrowPosition(0);
        settingsMenu.gameObject.SetActive(false);
        //statisticsMenu.gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

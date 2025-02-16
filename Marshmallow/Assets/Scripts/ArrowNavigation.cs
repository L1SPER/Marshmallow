using System;
using System.Collections;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class ArrowNavigation : MonoBehaviour
{
    #region 
    /* [SerializeField] private Image arrowImage;
    private RectTransform arrowRectTransform;
    private GameObject lastSelectedObject; // last selected button
    [SerializeField] GameObject firstSelectedButton;
    private InputManager inputManager;
    private SceneLoaderManager sceneLoaderManager;
    [SerializeField] float yOffset;
    private void Start()
    {
        arrowRectTransform = arrowImage.GetComponent<RectTransform>();
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        lastSelectedObject=null;
        
        inputManager = ManagerHub.Instance.GetManager<InputManager>();
        sceneLoaderManager = ManagerHub.Instance.GetManager<SceneLoaderManager>();

        if (inputManager != null)
        {
            inputManager.OnNavigateEvent += HandleNavigation;
            inputManager.OnSubmitEvent += HandleSubmit;
            inputManager.OnBackEvent += HandleBack;
        }
    }
    private void OnDisable()
    {
        inputManager.OnNavigateEvent -= HandleNavigation;
        inputManager.OnSubmitEvent -= HandleSubmit;
        inputManager.OnBackEvent -= HandleBack;
    } */
    #endregion
    #region 

    /* private InputManager inputManager;
    private SceneLoaderManager sceneLoaderManager;
    [SerializeField] Image arrowImage;
    public Button[] buttons;
    [SerializeField] float yOffset; // Offset for arrow image
    public int currentIndex = 0; // Index of arrow image

    private void Start()
    {
        inputManager = ManagerHub.Instance.GetManager<InputManager>();
        sceneLoaderManager = ManagerHub.Instance.GetManager<SceneLoaderManager>();

        if (inputManager != null)
        {
            inputManager.OnNavigateEvent += HandleNavigation;
            inputManager.OnBackEvent += HandleBack;
        }

        // Choose first button 
        UpdateArrowPosition(currentIndex);
        //EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }
    private void OnDisable()
    {
        inputManager.OnNavigateEvent -= HandleNavigation;
        inputManager.OnBackEvent -= HandleBack;
    } 
    
    private void MoveToNextButton()
    {
        currentIndex = (currentIndex + 1) % buttons.Length;
        UpdateArrowPosition(currentIndex);
    }

    private void MoveToPreviousButton()
    {
        currentIndex = (currentIndex - 1) % buttons.Length;
        if (currentIndex < 0)
            currentIndex += buttons.Length;

        UpdateArrowPosition(currentIndex);
    }
    public void SelectButton(int index)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttons[index].gameObject);
        //buttons[index].Select();
    }
    IEnumerator SelectButton(GameObject _gameObject)
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_gameObject);
        //_gameObject.GetComponent<Button>().OnDeselect(null);
        //_gameObject.GetComponent<Button>().OnSelect(null); 
    }
    public void UpdateArrowPosition(int index)
    {
        //SelectButton(index);
        Vector3 targetPosition = buttons[index].transform.position;
        //Adds offset to x
        arrowImage.transform.position = new Vector3(targetPosition.x + yOffset, targetPosition.y, targetPosition.z);
    }
    public void UpdateArrowPosition(GameObject _gameObject)
    {
        StartCoroutine(SelectButton(_gameObject));
         //Adds offset to x
        arrowImage.transform.position = new Vector3(_gameObject.transform.position.x + yOffset,_gameObject.transform.position.y, _gameObject.transform.position.z);
    }
    public void ResetCurrentIndex()
    {
        currentIndex = 0;
    }
    private void Update()
    {
        //Debug.Log("Last selected obj : "+lastSelectedObject.name);
        //Debug.Log("Current selected obj : "+EventSystem.current.currentSelectedGameObject.name);

    }
 
    private void HandleNavigation(Vector2 direction)
    {
         if (direction.y > 0)
         {
             MoveToPreviousButton();
         }
         else if (direction.y < 0)
         {
             MoveToNextButton();
         } 
        //} 

        //CheckLastObjectvsNewObject();
    } 

    /// <summary>
    /// Compares EventSystem.current.currentSelectedGameObject vs current. If they are not same, updates the arrow image
    /// </summary>
    /* private void CheckLastObjectvsNewObject()
    {
        GameObject currentSelectedObject = EventSystem.current.currentSelectedGameObject;
        if (currentSelectedObject != lastSelectedObject)
        {
            OnSelectedObjectChanged(lastSelectedObject, currentSelectedObject);
            lastSelectedObject = currentSelectedObject;
        }
    }
    /// <summary>
    /// Compare last selected object vs current. If they are not same, updates the arrow image
    /// </summary>
    public void CheckLastObjectvsNewObject(GameObject currentSelectedObject)
    {
        if (currentSelectedObject != lastSelectedObject)
        {
            OnSelectedObjectChanged(lastSelectedObject, currentSelectedObject);
            lastSelectedObject = currentSelectedObject;
        }
    }
    /// <summary>
    /// When event system current gameObject changes, updates the arrow image
    /// </summary>
    private void OnSelectedObjectChanged(GameObject previousObject, GameObject newObject)
    {
        if(newObject != null)
        {
            Debug.Log($"Selected object changed from {previousObject?.name} to {newObject?.name}");
        }
        else{
            Debug.Log($"Selected object cleared. Previous object was {previousObject?.name}");
        }
        UpdateArrowImage(newObject);
    }
    /// <summary>
    /// When event system current gameObject changes, updates the arrow image
    /// </summary>
     public void OnSelectedObjectChanged( GameObject newObject)
    {
        if(newObject != null)
        {
            Debug.Log($"Selected object changed to {newObject?.name}");
        }
        else{
            Debug.Log($"Selected object cleared.");
        }
        UpdateArrowImage(newObject);
    }
    /// <summary>
    /// Updates the position of arrow image
    /// </summary>
    
     private void UpdateArrowImage(GameObject newObject)
    {
        if(newObject== null)
            return;

        Debug.Log(newObject.name);
        RectTransform selectedRect= newObject.GetComponent<RectTransform>();
        Debug.Log(selectedRect.position);

        if(selectedRect!= null)
        {
            Vector3 arrowPosition= selectedRect.position;
            arrowPosition.x -= selectedRect.rect.width/2 +yOffset;
            arrowImage.GetComponent<RectTransform>().position= arrowPosition;
        }
        else
        {
            Debug.LogError("Selected rect is null !!");
        }
    }   
    private	void HandleSubmit()
    {
        //lastSelectedObject=null;
        EventSystem.current.SetSelectedGameObject(null);
        //CheckLastObjectvsNewObject();
    }
    private void HandleBack()
    {
        //lastSelectedObject=null;
        EventSystem.current.SetSelectedGameObject(null);
        /* if (sceneLoaderManager != null)
        {
            sceneLoaderManager.GoBack();
        } 
    }
   #endregion

    [Header("Arrow Image & Buttons")]
    [SerializeField] private Image arrowImage;
    [SerializeField] private Button[] buttons;

    private void Start()
    {
        // Butonlar seçildiğinde event ekleyerek arrow'u güncelle
        AddButtonListeners();
    }

    private void AddButtonListeners()
    {
        foreach (Button button in buttons)
        {
            EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry entry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.Select
            };
            entry.callback.AddListener((eventData) => UpdateArrowPosition(button));

            trigger.triggers.Add(entry);
        }
    }

    public void SetInitialButton()
    {
        if (buttons.Length > 0)
        {
            EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
            UpdateArrowPosition(buttons[0]);
        }
    }

    private void UpdateArrowPosition(Button selectedButton)
    {
        if (selectedButton == null || arrowImage == null) return;

        RectTransform buttonRect = selectedButton.GetComponent<RectTransform>();
        if (buttonRect != null)
        {
            Vector3 arrowPosition = buttonRect.position;
            arrowPosition.x -= 50; // Okun butonun solunda olması için
            arrowImage.rectTransform.position = arrowPosition;
        }
    }
    */
    #endregion

    [Header("Arrow Image & Buttons")]
    [SerializeField] private Image arrowImage;
    [SerializeField] public Button[] buttons;
    [SerializeField] private float arrowOffset;

    private void Start()
    {
        AddButtonListeners();
    }
    private void AddButtonListeners()
    {
        foreach(Button button in buttons)
        {
            EventTrigger trigger= button.AddComponent<EventTrigger>();

            EventTrigger.Entry entry= new EventTrigger.Entry
            {
                eventID = EventTriggerType.Select
            };

            entry.callback.AddListener((eventData) => UpdateArrowPosition(button));
            trigger.triggers.Add(entry);
        }
    }
    public void SetInitialButton()
    {
        if(buttons.Length>0)
        {
            EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
            UpdateArrowPosition(buttons[0]);
        }
    }
    public IEnumerator SetButtonNextFrame(GameObject button)
    {
        yield return null; // Bir frame bekle
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }
    private void UpdateArrowPosition(Button button)
    {
        if(arrowImage ==null || button==null ) return;

        RectTransform arrowRect= button.GetComponent<RectTransform>();

        if(arrowRect!= null)
        {
            Vector3 arrowPosition= arrowRect.position;
            arrowPosition.x -= arrowOffset;
            arrowImage.rectTransform.position= arrowPosition;
        }
    }
}

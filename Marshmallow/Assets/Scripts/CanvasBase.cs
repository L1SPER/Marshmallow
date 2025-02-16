using UnityEngine;
using UnityEngine.UI;

public abstract class CanvasBase : MonoBehaviour, ICanvasBackHandler
{
    public enum BackActionType
    {
        None,
        LoadScene,
        OpenPreviousMenu            
    }
    [SerializeField] protected MenuType menuType;
    [SerializeField] public BackActionType backActionType;
    [SerializeField, HideInInspector] protected string sceneToLoad;
    [SerializeField, HideInInspector] protected Button backButton;

    protected virtual void Awake()
    {
        bool wasInactive = !gameObject.activeSelf;
        if (wasInactive) gameObject.SetActive(true);
        
        if(ManagerHub.Instance==null)
            Debug.LogError("Instance is null");
        if(!ManagerHub.Instance.GetManager<MenuManager>().ContainsMenu(this.gameObject))
            ManagerHub.Instance.GetManager<MenuManager>().AddToMenus(this.gameObject,menuType);

        if (wasInactive) gameObject.SetActive(false);
    }
    protected virtual void OnEnable()
    {
        ManagerHub.Instance.GetManager<InputManager>().OnBackEvent += OnBack;
    }
    protected virtual void OnDisable()
    {
        ManagerHub.Instance.GetManager<InputManager>().OnBackEvent -= OnBack;
    }
    public virtual void OnBack()
    {
        switch(backActionType)
        {
            case BackActionType.LoadScene:
                if(!string.IsNullOrEmpty(sceneToLoad))
                {
                    ManagerHub.Instance.GetManager<SceneLoaderManager>().LoadScene(sceneToLoad);   
                }
                else
                {
                    Debug.LogWarning("SceneToLoad variable is empty");
                }
                break;
            case BackActionType.OpenPreviousMenu:
                if(backButton !=null)
                {
                    backButton.onClick.Invoke();
                }
                else
                {
                    Debug.LogWarning("Back button is null");
                }
                break;
            case BackActionType.None:
                Debug.LogWarning("There is not back action type");
                break;
        }
    }
}

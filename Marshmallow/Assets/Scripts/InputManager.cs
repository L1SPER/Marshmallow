using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private InputActionAsset inputActions;
    public delegate void BackAction();
    public event BackAction OnBackEvent;
    public delegate void NavigateAction(Vector2 direction);
    public event NavigateAction OnNavigateEvent;

    public delegate void SubmitAction();
    public event SubmitAction OnSubmitEvent;

    private void Awake()
    {
        ManagerHub.Instance.RegisterManager(this);

        FindInputActionsAsset();

        inputActions.Enable();
    }
    //Loads Input Actions
    private void FindInputActionsAsset()
    {
        inputActions = Resources.Load<InputActionAsset>("InputSystem_Actions");
        if (inputActions == null)
        {
            Debug.LogError("Input actions load error!!!");
        }
    }
    private void OnEnable()
    {
        inputActions?.Enable();

        // Navigate aksiyonuna bağlan
        var navigateAction = GetAction("UI", "Navigate");
        var submitAction = GetAction("UI","Submit");
        var backAction = GetAction("UI","Cancel");

        if (navigateAction != null)
        {
            navigateAction.performed += HandleNavigate;
            //navigateAction.canceled +=HandleNavigate;
        }
        if (submitAction != null)
        {
            submitAction.performed += HandleSubmit;
            //submitAction.canceled += HandleSubmit;
        }

        if(backAction != null)
        {
            backAction.performed += HandleBack;
            //backAction.canceled += HandleBack;
        }
    }

    private void OnDisable()
    {
        inputActions?.Disable();

        var navigateAction = GetAction("UI", "Navigate");
        var submitAction = GetAction("UI", "Submit");
        var backAction = GetAction("UI","Cancel");

        if (navigateAction != null)
        {
            navigateAction.performed -= HandleNavigate;
            //navigateAction.canceled -=HandleNavigate;
        }
        if (submitAction != null)
        {
            submitAction.performed -= HandleSubmit;
            //submitAction.canceled -= HandleSubmit;
        }
        if(backAction!= null)
        {
            backAction.performed -=HandleBack;
            //backAction.canceled -= HandleBack;
        }
    }

    //Gets Input Actions
    public InputActionAsset GetInputActions()
    {
        return inputActions;
    }

    // Gets map
    public InputActionMap GetActionMap(string mapName)
    {
        if (GetInputActions() == null)
        {
            Debug.LogError("InputActionAsset is null! Make sure it is loaded correctly.");
            return null;
        }
        return GetInputActions().FindActionMap(mapName);
    }

    // Gets action
    public InputAction GetAction(string mapName, string actionName)
    {
        var actionMap = GetActionMap(mapName);
        if (actionMap == null)
        {
            Debug.LogError($"InputActionMap '{mapName}' bulunamadı!");
            return null;
        }

        var action = actionMap.FindAction(actionName);
        if (action == null)
        {
            Debug.LogError($"InputAction '{actionName}' bulunamadı!");
        }
        return action;
    }
    public void HandleNavigate(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        OnNavigateEvent?.Invoke(direction);
    }
    public void HandleSubmit(InputAction.CallbackContext context)
    {
        var selectedObj=UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        if(selectedObj !=null)
        {
            var button = selectedObj.GetComponent<Button>();
            //Selected objeyi secebilirim
            if( button != null)
            {
                button.onClick.Invoke();
            }
        }
    }
    public void HandleBack(InputAction.CallbackContext context)
    {   
        if(context.performed)
        {
            OnBackEvent?.Invoke();
        }
    }
}

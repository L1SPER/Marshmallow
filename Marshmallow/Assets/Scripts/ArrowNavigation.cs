using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ArrowNavigation : MonoBehaviour
{
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
        if(arrowImage ==null || button==null ) 
        {
            Debug.LogError("Arrow image or button is null");
            return;
        }

        RectTransform arrowRect= button.GetComponent<RectTransform>();

        if(arrowRect!= null)
        {
            Vector3 arrowPosition= arrowRect.position;
            arrowPosition.x -= arrowOffset;
            arrowImage.rectTransform.position= arrowPosition;
        }
        else
        {
            Debug.LogError("Arrow rect is null");
        }
    }
}

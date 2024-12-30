using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ArrowNavigation : MonoBehaviour
{
    [SerializeField] Image arrowImage; // Ok işareti
    [SerializeField] Button[] buttons; // Butonlar
    [SerializeField] float yOffset = 0.5f; // Ok işareti için offset
    private int currentIndex = 0;
    private void Start()
    {
        // İlk buton seçili olarak başlat
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        
        // İlk seçili butonun pozisyonunu ayarla
        UpdateArrowPosition(buttons[0].transform);
    }

    private void Update()
    {
        // Seçili butonu kontrol et
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        if (selectedObject != null)
        {
            Button selectedButton = selectedObject.GetComponent<Button>();
            if (selectedButton != null)
            {
                // Seçili buton değiştiğinde ok işaretini güncelle
                UpdateArrowPosition(selectedButton.transform);
            }
        }
         // Aşağı ok tuşuna basıldığında butonlar arasında geçiş yap
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Mevcut buton index'ini güncelle
            currentIndex = (currentIndex + 1) % buttons.Length;

            // Yeni seçili butonun pozisyonunu güncelle
            EventSystem.current.SetSelectedGameObject(buttons[currentIndex].gameObject);

            // Ok işaretinin pozisyonunu güncelle
            UpdateArrowPosition(buttons[currentIndex].transform);
        }

        // Yukarı ok tuşuna basıldığında butonlar arasında geçiş yap
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Mevcut buton index'ini güncelle
            currentIndex = (currentIndex - 1 + buttons.Length) % buttons.Length;

            // Yeni seçili butonun pozisyonunu güncelle
            EventSystem.current.SetSelectedGameObject(buttons[currentIndex].gameObject);

            // Ok işaretinin pozisyonunu güncelle
            UpdateArrowPosition(buttons[currentIndex].transform);
        }
    }

    private void UpdateArrowPosition(Transform buttonTransform)
    {
        // Ok işaretinin pozisyonunu seçilen butona göre ayarla
        Vector3 targetPosition = buttonTransform.position;

        // Y offset ekle
        arrowImage.transform.position = new Vector3(targetPosition.x+ yOffset, targetPosition.y , targetPosition.z);
    }
   
}

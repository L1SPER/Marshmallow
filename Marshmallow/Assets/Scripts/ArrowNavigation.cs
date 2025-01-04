using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ArrowNavigation : MonoBehaviour
{
    [SerializeField] Image arrowImage; // Ok işareti
    public Button[] buttons; // Butonlar
    [SerializeField] float yOffset ; // Ok işareti için offset
    public int currentIndex = 0;
    private void Start()
    {
        // İlk buton seçili olarak başlat
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        
        // İlk seçili butonun pozisyonunu ayarla
        UpdateArrowPosition(currentIndex);
    }

    private void Update()
    {
        Debug.Log("Index: " + currentIndex);
        // Seçili butonu kontrol et
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        if (selectedObject != null)
        {
            Button selectedButton = selectedObject.GetComponent<Button>();
            if (selectedButton != null)
            {
                // Seçili buton değiştiğinde ok işaretini güncelle
                UpdateArrowPosition(currentIndex);
            }
        }
         // Aşağı ok tuşuna basıldığında butonlar arasında geçiş yap
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Mevcut buton index'ini güncelle
            currentIndex = (currentIndex + 1) % buttons.Length;

            // Ok işaretinin pozisyonunu güncelle
            UpdateArrowPosition(currentIndex);
        }

        // Yukarı ok tuşuna basıldığında butonlar arasında geçiş yap
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Mevcut buton index'ini güncelle
            currentIndex = (currentIndex - 1 + buttons.Length) % buttons.Length;

            // Ok işaretinin pozisyonunu güncelle
            UpdateArrowPosition(currentIndex);
        }
    }

    
    public void UpdateArrowPosition(int index)
    {
        // Ok işaretinin pozisyonunu seçilen butona göre ayarla
        Vector3 targetPosition = buttons[index].transform.position;
        EventSystem.current.SetSelectedGameObject(buttons[index].gameObject);
        // X offset ekle
        arrowImage.transform.position = new Vector3(targetPosition.x+ yOffset, targetPosition.y , targetPosition.z);
    }
    public void ResetCurrentIndex() 
    {
        currentIndex = 0;
    }
   
}

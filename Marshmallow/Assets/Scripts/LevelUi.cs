using UnityEngine;
using UnityEngine.UI;

public class LevelUi : MonoBehaviour
{
    private bool isSuccessful = false;
    [SerializeField] private Image bgImage;
    [SerializeField] private Text levelText;
    [SerializeField] private Text levelHintText;
    [SerializeField] private float successfulTime;
}

using Unity.Mathematics;
using UnityEngine;

public class LevelUiManager : MonoBehaviour
{
    [SerializeField] private GameObject levelUiPrefab;
    [SerializeField] private GameObject bossUiPrefab;
    [SerializeField] private int size;
    [SerializeField] private int columnSize;
    [SerializeField] private int columnSpace;
    [SerializeField] private int rowSpace;

    [SerializeField] Vector3 startPosition;

    private void Start()
    {
        for (int i = 0; i < size; i++)
        {
            Vector3 pos= startPosition+ new Vector3(i % columnSize* columnSpace , i / columnSize * rowSpace, 0);
            GameObject levelUi = Instantiate(levelUiPrefab, pos ,quaternion.identity) as GameObject;
            levelUi.transform.SetParent(this.transform);
        }
    }

}

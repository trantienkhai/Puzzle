using UnityEngine;

public class ScoreFollowBackground : MonoBehaviour
{
    public Transform background;       
    public Vector3 offsetPixels;       

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (background != null)
        {
            Vector3 worldPos = background.position;
            float halfWidth = background.localScale.x / 2f;
            float halfHeight = background.localScale.y / 2f;

            Vector3 topLeft = worldPos + new Vector3(-halfWidth, halfHeight, 0);

            Vector3 screenPos = Camera.main.WorldToScreenPoint(topLeft);
            rectTransform.position = screenPos + offsetPixels;
        }
    }
}

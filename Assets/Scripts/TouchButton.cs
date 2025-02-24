using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TouchButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool Pressed;
    Image touchImage;
    float color = 1f;

    public float PointUp = 0.7f, PointDown = 1.0f;

    void Start()
    {
        touchImage = GetComponent<Image>();
        touchImage.color = new Color(color, color, color, PointUp);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        touchImage.color = new Color(color, color, color, PointDown);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
        touchImage.color = new Color(color, color, color, PointUp);
    }
}
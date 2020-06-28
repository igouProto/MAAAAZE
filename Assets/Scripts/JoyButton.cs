using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool pressed;

    public void OnPointerDown(PointerEventData evdata)
    {
        pressed = true;
    }
    public void OnPointerUp(PointerEventData evdata)
    {
        pressed = false;
    }
}

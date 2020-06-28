using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton2 : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
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

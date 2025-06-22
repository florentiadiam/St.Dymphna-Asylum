using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TextColorChanger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TMP_Text text;
    public Color normalColor = Color.white;
    public Color pressedColor = new Color32(125, 190, 255, 255); // light blue

    public void OnPointerDown(PointerEventData eventData)
    {
        text.color= pressedColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        text.color= normalColor;
    }
}

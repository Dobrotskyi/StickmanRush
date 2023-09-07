using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MySlider : Slider
{
    public bool IsHeld { get; private set; } = false;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        IsHeld = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        value = 0;
        IsHeld = false;
    }
}
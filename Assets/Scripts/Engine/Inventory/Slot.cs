using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler//, IPointerClickHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            SlotItem item = dropped.GetComponent<SlotItem>();
            item.parentAfterDrag = transform;
        }
    }

    public bool HasItem() => GetComponentInChildren<SlotItem>() != null;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            Debug.Log("double click");
        }
    }
}

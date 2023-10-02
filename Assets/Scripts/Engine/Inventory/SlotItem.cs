using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    public Image image;
    [HideInInspector]
    public Transform parentAfterDrag;
    [SerializeField]
    private Item item;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void AddItem(Item item, string sprite)
    {
        gameObject.AddComponent<Image>();
        var itemImage = GetComponent<Image>();
        itemImage.sprite = Resources.Load<Sprite>(sprite);
        itemImage.transform.localScale = Vector3.one;

        this.item = item;
        image = itemImage;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

}

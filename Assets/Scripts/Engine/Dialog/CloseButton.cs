using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CloseButton : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent<bool> DialogEnded;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponentInParent<DialogWindow>().gameObject.SetActive(false);
        DialogEnded.Invoke(true);
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DialogAnswer : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    private TMP_Text text;
    private int id;

    public UnityEvent<int> AnswerSelected;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        text.color = Color.yellow;
    }

    public void Clear()
    {
        text.text = null;
        id = 0;
    }

    public void SetTextValue(string value)
    {
        text.text = value;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AnswerSelected.Invoke(id);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.yellow;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.white;
    }

    public int Id
    {
        set { id = value; }
        get { return id; }
    }
}

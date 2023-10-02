using UnityEngine;

public class DropItem : MonoBehaviour, IWithProbability, ISelectable
{
    [SerializeField]
    private Texture2D commonCursorTexture;

    [SerializeField]
    private Texture2D takeCursorTexture;

    [SerializeField]
    private int id;

    [SerializeField]
    private Object item;

    [SerializeField]
    private string imageSprite;

    [SerializeField]
    private int count;

    [SerializeField]
    private float probability;

    public bool IsEmpty() => item == null;

    public void IncreaseCount(int value)
    {
        count += value;
    }

    public float Probability()
    {
        return probability;
    }

    public void Selected()
    {
    }

    public void Unselected()
    {
    }

    void OnMouseOver()
    {
        UnityEngine.Cursor.SetCursor(takeCursorTexture, Vector3.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        UnityEngine.Cursor.SetCursor(commonCursorTexture, Vector3.zero, CursorMode.Auto);
    }

    public int Id
    {
        get { return id; }
    }

    public Object Item
    {
        get { return item; }
    }

    public string ImageSprite
    {
        get { return imageSprite; }
    }

    public int Count
    {
        get { return count; }
    }
}

using UnityEngine;

public class ItemPanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void MakeVisible()
    {
        canvasGroup.alpha = 1;
    }

    public void MakeInvisible()
    {
        canvasGroup.alpha = 0;
    }

    public bool IsVisible() => canvasGroup.alpha != 0;
}

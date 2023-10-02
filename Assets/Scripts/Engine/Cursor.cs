using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursorTexture;

    void Start()
    {
        UnityEngine.Cursor.SetCursor(cursorTexture, Vector3.zero, CursorMode.Auto);
    }
}

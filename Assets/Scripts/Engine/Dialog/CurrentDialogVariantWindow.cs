using TMPro;
using UnityEngine;

public class CurrentDialogVariantWindow : MonoBehaviour
{
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        text.color = Color.yellow;
    }

    public void SetTextValue(string textValue)
    {
        text.text = textValue;
    }
}

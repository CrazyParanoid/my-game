using UnityEngine;

public class DialogWindow : MonoBehaviour
{
    private AnswersWindow answersWindow;
    private CurrentDialogVariantWindow variantWindow;

    void Start()
    {
        answersWindow = GetComponentInChildren<AnswersWindow>();
        variantWindow = GetComponentInChildren<CurrentDialogVariantWindow>();
    }

    private void Awake()
    {
        answersWindow = GetComponentInChildren<AnswersWindow>();
        variantWindow = GetComponentInChildren<CurrentDialogVariantWindow>();
    }

    public void SetDialog(Dialog dialog)
    {
        answersWindow.InitAnswers(dialog.ShowCurrentAnswers());
        variantWindow.SetTextValue(dialog.CurrentVariantText);
    }

    public void ClearAnswersWindow()
    {
        answersWindow.ClearAnswers();
    }
}

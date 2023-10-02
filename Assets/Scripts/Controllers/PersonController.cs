using UnityEngine;
using Zenject;

public class PersonController : BasicNpcController<Person>, INteractable
{
    [Inject]
    private readonly DialogWindow dialogWindow;

    [Inject]
    public HeroController heroController;

    protected override void RunBehavior()
    {
    }

    protected override void InitComponents()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        dialogWindow.gameObject.SetActive(true);

        var dialog = character.Dialog;
        dialog.BackToDefaultVariant();
        dialogWindow.SetDialog(dialog);
    }

    public void EndInteract()
    {
        targetPointer.SetActive(false);
    }

    public void TakeAnswer(int answerId)
    {
        var hero = heroController.Character();

        character.TakeAnswer(answerId, hero.Intelligence);

        dialogWindow.ClearAnswersWindow();
        dialogWindow.SetDialog(character.Dialog);
    }
}

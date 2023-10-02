using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Person", fileName = "Person")]
public class Person : Npc
{
    [SerializeField]
    private Dialog dialog;

    public Person(Dialog dialog) : base(0, null, null)
    {
        this.dialog = dialog;
    }

    public Variant StartDialog => dialog.Start();

    public void BackToDefaultDialogVariant()
    {
        dialog.BackToDefaultVariant();
    }

    public Variant TakeAnswer(int answerId, float intelligence) => 
        dialog.TakeAnswer(answerId, intelligence);

    public override void Die()
    {
        throw new NotImplementedException("Not implemented");
    }

    public override Hit Damage()
    {
        throw new NotImplementedException("Not implemented");
    }

    public override void ReceiveDamage(Hit hit)
    {
        throw new NotImplementedException("Not implemented");
    }

    public Dialog Dialog { get { return dialog; } }
}

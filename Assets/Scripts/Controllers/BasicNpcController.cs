using UnityEngine;

public abstract class BasicNpcController<T> : BasicCharacterController<T>, ISelectable where T : Character
{
    public bool patroll = true;

    protected GameObject targetPointer;

    private void Awake()
    {
        targetPointer = transform.Find("TargetPointer").gameObject;
    }

    protected override void RunBehavior()
    {
    }

    public void Selected()
    {
        healthBar.OnHealthReducedByDamage(character.CurrentHealth);
        healthBar.Enable();

        targetPointer.SetActive(true);
    }

    public void Unselected()
    {
        healthBar.Disable();
        targetPointer.SetActive(false);
    }
}

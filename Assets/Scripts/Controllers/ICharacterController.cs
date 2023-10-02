using UnityEngine;

public interface ICharacterController
{

    public void ReceiveDamage(Hit hit, Transform target);

    public bool IsDead();

    public Character Character();
}

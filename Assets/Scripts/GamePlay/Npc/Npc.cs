using UnityEngine;

[CreateAssetMenu(menuName = "Npc", fileName = "Npc")]
public class Npc : Character
{
    private bool attacked = false;

    [SerializeField]
    private float expirience;

    public Npc(float expirience, Health health, Characteristics characteristics)
      : base(health, characteristics)
    {
        this.expirience = expirience;
    }

    public Npc(bool attacked, float expirience, Health health, Characteristics characteristics)
     : base(health, characteristics)
    {
        this.attacked = attacked;
        this.expirience = expirience;
    }

    public override void Die()
    {
        attacked = false;
        base.Die();
    }

    public override void ReceiveDamage(Hit hit)
    {
        attacked = true;
        base.ReceiveDamage(hit);
    }

    public void SetAttackedToFalseIfEnemyDead(Character enemy)
    {
        if (!IsDead())
        {
            if (attacked)
            {
                if (enemy.IsDead())
                {
                    attacked = false;
                }
            }
        }
    }

    public bool IsAattacked() => attacked;

    public float Expirience
    {
        get { return expirience; }
    }
}

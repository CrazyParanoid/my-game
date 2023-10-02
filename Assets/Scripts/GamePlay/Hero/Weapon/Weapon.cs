using UnityEngine;

public abstract class Weapon: ScriptableObject, Item
{
    [SerializeField]
    private Damage damage;

    protected Weapon(Damage damage)
    {
        this.damage = damage;
    }

    public Hit HitDamage
    {
        get
        {
            return new Hit(
            physicalDamage: damage.BasicPhysicalDamage,
            fireDamage: damage.BasicFireDamage,
            iceDamage: damage.BasicIceDamage,
            windDamage: damage.BasicWindDamage
            );
        }
    }
}

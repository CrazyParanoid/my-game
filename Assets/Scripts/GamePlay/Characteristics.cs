using UnityEngine;

[CreateAssetMenu(menuName = "Characteristics", fileName = "Characteristics")]
public class Characteristics : ScriptableObject
{
    [SerializeField]
    private float strength;
    [SerializeField]
    private float dexterity;
    [SerializeField]
    private float intelligence;
    [SerializeField]
    private Damage damage;
    [SerializeField]
    private Resistance resistance;

    [SerializeField]
    private float incrementStep = 2;
    [SerializeField]
    private float damageCoefficient = 0.08f;

    public Characteristics(float strength, float dexterity, 
        float intelligence, Damage damage, Resistance resistance)
    {
        this.strength = strength;
        this.dexterity = dexterity;
        this.intelligence = intelligence;
        this.damage = damage;
        this.resistance = resistance;
    }

    public Hit HitDamage()
    {
        return new Hit(damage.BasicPhysicalDamage, damage.BasicFireDamage,
            damage.BasicIceDamage, damage.BasicWindDamage);
    }

    public void IncreaseByLevel()
    {
        strength *= incrementStep;
        dexterity *= incrementStep;
        intelligence *= incrementStep;

        damage.BasicPhysicalDamage = CalculateBasicPhysicalDamage();
    }

    private float CalculateBasicPhysicalDamage()
    {
        return dexterity * strength * damageCoefficient;
    }

    public Resistance Resistance
    {
        get { return resistance; }
    }

    public float Intelligence { get { return intelligence; } }
}

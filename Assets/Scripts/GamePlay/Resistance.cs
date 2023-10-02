using UnityEngine;

[CreateAssetMenu(menuName = "Resistance", fileName = "Resistance")]
public class Resistance : ScriptableObject
{
    [SerializeField]
    private float basicPhysicalDamageResistance;
    [SerializeField]
    private float basicFireDamageResistance;
    [SerializeField]
    private float basicIceDamageResistance;
    [SerializeField]
    private float basicWindDamageResistance;

    [SerializeField]
    private float resistanceCoefficient = 0.1f;

    public Resistance(float basicPhysicalDamageResistance, float basicFireDamageResistance,
        float basicIceDamageResistance, float basicWindDamageResistance)
    {
        this.basicPhysicalDamageResistance = basicPhysicalDamageResistance;
        this.basicFireDamageResistance = basicFireDamageResistance;
        this.basicIceDamageResistance = basicIceDamageResistance;
        this.basicWindDamageResistance = basicWindDamageResistance;
    }

    public static Resistance operator +(Resistance basic, Resistance armor) =>
        new(
            basic.basicPhysicalDamageResistance + armor.BasicPhysicalDamageResistance,
            basic.basicFireDamageResistance + armor.basicFireDamageResistance,
            basic.basicIceDamageResistance + armor.basicIceDamageResistance,
            basic.basicWindDamageResistance + armor.basicWindDamageResistance
            );

    public float BasicPhysicalDamageResistance
    {
        get { return basicPhysicalDamageResistance * resistanceCoefficient; }
    }

    public float BasicFireDamageResistance
    {
        get { return basicFireDamageResistance * resistanceCoefficient; }
    }

    public float BasicIceDamageResistance
    {
        get { return basicIceDamageResistance * resistanceCoefficient; }
    }

    public float BasicWindDamageResistance
    {
        get { return basicWindDamageResistance * resistanceCoefficient; }
    }
}

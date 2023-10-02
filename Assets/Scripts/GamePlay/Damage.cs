using UnityEngine;

[CreateAssetMenu(menuName = "Damage", fileName = "Damage")]
public class Damage: ScriptableObject
{
    [SerializeField]
    private float basicPhysicalDamage;
    [SerializeField]
    private float basicFireDamage;
    [SerializeField]
    private float basicIceDamage;
    [SerializeField]
    private float basicWindDamage;

    public Damage(float basicPhysicalDamage, float basicFireDamage, float basicIceDamage, float basicWindDamage)
    {
        this.basicPhysicalDamage = basicPhysicalDamage;
        this.basicFireDamage = basicFireDamage;
        this.basicIceDamage = basicIceDamage;
        this.basicWindDamage = basicWindDamage;
    }
    
    public float BasicPhysicalDamage
    {
        get { return this.basicPhysicalDamage; }

        set { this.basicPhysicalDamage = value;}
    }

    public float BasicFireDamage
    {
        get { return basicFireDamage; }
    }

    public float BasicIceDamage
    {
        get { return basicIceDamage; }
    }

    public float BasicWindDamage
    {
        get { return basicWindDamage; }
    }
}

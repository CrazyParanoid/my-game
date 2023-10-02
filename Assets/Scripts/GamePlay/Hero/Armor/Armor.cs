using UnityEngine;

[CreateAssetMenu(menuName = "Armor", fileName = "Armor")]
public abstract class Armor: ScriptableObject, Item
{
    [SerializeField]
    private Resistance resistance;

    protected Armor(Resistance resistance)
    {
        this.resistance = resistance;
    }

    public Resistance Resistance
    {
        get { return resistance; }
    }
}

using UnityEngine;

[CreateAssetMenu(menuName = "HealthPotion", fileName = "HealthPotion")]
public class HealthPotion : ScriptableObject, Item
{
    [SerializeField]
    private float value;
    
    public HealthPotion(float value)
    {
        this.value = value;
    }

    public float Value
    {
        get { return value; }
    }
}

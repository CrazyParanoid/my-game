using UnityEngine;

[CreateAssetMenu(menuName = "Level", fileName = "Level")]
public class Level : ScriptableObject
{
    private int value;
    [SerializeField]
    private float expirience;
    [SerializeField]
    private float upExpirience;

    [SerializeField]
    private float expirienceCoefficient = 0.7f;

    public Level(int value, float expirience, float upExpirience)
    {
        this.value = value;
        this.expirience = expirience;
        this.upExpirience = upExpirience;
    }

    public bool IncreaseExpirience(float expirienceValue)
    {
        expirience += expirienceValue;
        if (expirience >= upExpirience)
        {
            Up();
            return true;
        }
        return false;
    }

    private void Up()
    {
        value += 1;
        expirience = 0;
        upExpirience += upExpirience*expirienceCoefficient;
    }

    public float Value
    {
        get { return value; }
    }

    public float CurrentExpirience
    {
        get { return expirience; }
    }

    public float UpExpirience
    {
        get { return upExpirience; }
    }
}

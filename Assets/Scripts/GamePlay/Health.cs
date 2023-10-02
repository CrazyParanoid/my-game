using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Health", fileName = "Health")]
public class Health : ScriptableObject
{
    [SerializeField]
    private float currentValue;
    [SerializeField]
    private float maxValue;
    [SerializeField]
    private float regenCoefficient = 0.0005f;

    public Health(float currentValue, float maxValue)
    {
        this.currentValue = currentValue;
        this.maxValue = maxValue;
    }

    public void ReduceOnDamage(Hit hit, Resistance resistance)
    {
        currentValue -= CalculateGeneralDamageValue(hit, resistance);
        currentValue = Math.Max(0, currentValue);
    }

    public void Replenish(HealthPotion healthPotion)
    {
        currentValue += healthPotion.Value;
        if(currentValue > maxValue)
        {
            currentValue = maxValue;
        }
    }

    private float CalculateGeneralDamageValue(Hit hit, Resistance resistance)
    {
        var physicalDamage = hit.Physicaldamage - resistance.BasicPhysicalDamageResistance;
        var fireDamage = hit.FireDamage - resistance.BasicFireDamageResistance;
        var iceDamageResistance = hit.IceDamage - resistance.BasicIceDamageResistance;
        var windDamageResistance = hit.WindDamage - resistance.BasicWindDamageResistance;

        return Math.Max(0, physicalDamage) 
            + Math.Max(0, fireDamage)
            + Math.Max(0, iceDamageResistance)
            + Math.Max(0, windDamageResistance);
    }

    public bool IsLessOrEqualsZero() => currentValue <= 0;

    public float Regen(float strength)
    {
        return regenCoefficient * strength * maxValue;
    }

    public float CurrentValue
    {
        get { return currentValue; }
    }

    public float CalculatereducedHealthPercentage()
    {
        return currentValue / (maxValue * 0.01f);
    }

    public float MaxValue
    {
        get { return maxValue; }
    }

    private void OnValidate()
    {
        if (currentValue > maxValue)
            throw new ArgumentException("currentValue can't be greater maxValue");
    }
}

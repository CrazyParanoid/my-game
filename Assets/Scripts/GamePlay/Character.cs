using System;
using UnityEngine;

//Добавить реген
public abstract class Character : ScriptableObject
{
    [SerializeField]
    protected Health health;
    [SerializeField]
    protected Characteristics characteristics;

    public event Action<bool> OnDeath;
    public event Action<float> OnHealthReducedByDamage;

    private bool dead = false;

    protected Character(Health health, Characteristics characteristics)
    {
        this.health = health;
        this.characteristics = characteristics;
    }

    public virtual void ReceiveDamage(Hit hit)
    {
        health.ReduceOnDamage(hit, GetResistance());
        OnHealthReducedByDamage?.Invoke(health.CalculatereducedHealthPercentage());

        if (health.IsLessOrEqualsZero())
        {
            Die();
        }
    }

    protected virtual Resistance GetResistance() => characteristics.Resistance;

    public virtual void Die()
    {
        dead = true;
        OnDeath?.Invoke(dead);
    }

    public virtual Hit Damage()
    {
         return characteristics.HitDamage();
    }

    public float CurrentHealth
    {
        get
        {
            return health.CalculatereducedHealthPercentage();
        }
    }

    public float Intelligence { get { return characteristics.Intelligence; } }

    public bool IsDead() => dead;

    public Character Copy()
    {
        Health copiedHealth = Instantiate(health);
        Characteristics copiedCharacteristics = Instantiate(characteristics);
        Character character = Instantiate(this);

        character.health = copiedHealth;
        character.characteristics = copiedCharacteristics;

        return character;
    }
}

public class Hit
{
    private readonly float physicalDamage;
    private readonly float fireDamage;
    private readonly float iceDamage;
    private readonly float windDamage;

    public Hit(float physicalDamage, float fireDamage, float iceDamage, float windDamage)
    {
        this.physicalDamage = physicalDamage;
        this.fireDamage = fireDamage;
        this.iceDamage = iceDamage;
        this.windDamage = windDamage;
    }

    public static Hit operator +(Hit basic, Hit weapon) =>
        new(
            physicalDamage: basic.physicalDamage + weapon.physicalDamage,
            fireDamage: basic.fireDamage + weapon.fireDamage,
            iceDamage: basic.iceDamage + weapon.iceDamage,
            windDamage: basic.windDamage + weapon.windDamage
        );

    public float Physicaldamage
    {
        get { return physicalDamage; }
    }

    public float FireDamage
    {
        get { return fireDamage; }
    }

    public float WindDamage
    {
        get { return windDamage; }
    }
    public float IceDamage
    {
        get { return iceDamage; }
    }
}

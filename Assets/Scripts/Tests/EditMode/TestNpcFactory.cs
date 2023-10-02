public class TestNpcFactory
{
    public static Npc NewAttakedNpc() =>
        new(
            expirience: TestNpcValues.EXPIRIENCE,
            health: NewNpcHealth(),
            characteristics: NewNpcCharacteristics(),
            attacked: true
            );

    public static Npc NewNpc() =>
       new(
           expirience: TestNpcValues.EXPIRIENCE,
           health: NewNpcHealth(),
           characteristics: NewNpcCharacteristics()
           );

    public static Npc NewDeadNpc() 
    {
        var npc = NewNpc();
        npc.Die();
        return npc;
    }

    public static Npc NewDeadNpcWithLargeExpirience()
    {
        var npc = NewNpcWithLargeExpirience();
        npc.Die();
        return npc;
    }

    private static Npc NewNpcWithLargeExpirience() =>
        new(
            expirience: TestNpcValues.LARGE_EXPIRIENCE,
            health: NewNpcHealth(),
            characteristics: NewNpcCharacteristics()
            );

    private static Characteristics NewNpcCharacteristics() =>
        new(
            strength: TestNpcValues.NPC_STRENGHT,
            dexterity: TestNpcValues.NPC_DEXTERITY,
            intelligence: TestNpcValues.NPC_INTELLIGENCE,
            damage: BasicNpcDamage(),
            resistance: NewNpcResistance()
        );

    private static Resistance NewNpcResistance() =>
        new(
            basicPhysicalDamageResistance: TestNpcValues.BASIC_PHYSICAL_NPC_DAMAGE,
            basicFireDamageResistance: TestNpcValues.BASIC_FIRE_NPC_DAMAGE,
            basicIceDamageResistance: TestNpcValues.BASIC_ICE_NPC_DAMAGE,
            basicWindDamageResistance: TestNpcValues.BASIC_WIND_NPC_DAMAGE
            );

    private static Damage BasicNpcDamage() =>
        new(
            basicFireDamage: TestNpcValues.BASIC_FIRE_NPC_RESISTANCE,
            basicIceDamage: TestNpcValues.BASIC_ICE_NPC_RESISTANCE,
            basicPhysicalDamage: TestNpcValues.BASIC_PHYSICAL_NPC_RESISTANCE,
            basicWindDamage: TestNpcValues.BASIC_WIND_NPC_RESISTANCE
        );

    private static Health NewNpcHealth() =>
        new(
            currentValue: TestNpcValues.CURRENT_NPC_HEALTH_VALUE,
            maxValue: TestNpcValues.MAX_NPC_HEALTH_VALUE
            );
}

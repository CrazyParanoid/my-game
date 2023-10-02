public class TestHeroFactory
{
    //Hero
    public static Hero NewHero() =>
         new(
                health: NewHeroHealth(),
                characteristics: NewHeroCharacteristics(),
                level: NewLevel(),
                weapon: NewSword(),
                armor: NewGrizaKorvoArmor()
            );

    public static Hero NewHeroWithReducedHealth() =>
       new(
              health: NewReducedHeroHealth(),
              characteristics: NewHeroCharacteristics(),
              level: NewLevel(),
              weapon: NewSword(),
              armor: NewGrizaKorvoArmor()
          );

    private static Level NewLevel() =>
        new(
            value: TestHeroValues.FIRST_LEVEL,
            expirience: 0,
            upExpirience: TestHeroValues.BASIC_UP_EXPIRIENCE
           );

    private static Characteristics NewHeroCharacteristics() =>
        new(
            strength: TestHeroValues.HERO_STRENGHT,
            dexterity: TestHeroValues.HERO_DEXTERITY,
            intelligence: TestHeroValues.HERO_INTELLIGENCE,
            damage: BasicHeroDamage(),
            resistance: NewBasicResistance()
        );

    private static Resistance NewBasicResistance() =>
        new(
            basicPhysicalDamageResistance: TestHeroValues.BASIC_PHYSICAL_HERO_RESISTANCE,
            basicFireDamageResistance: TestHeroValues.BASIC_FIRE_HERO_RESISTANCE,
            basicIceDamageResistance: TestHeroValues.BASIC_ICE_HERO_DAMAGE,
            basicWindDamageResistance: TestHeroValues.BASIC_WIND_HERO_RESISTANCE
            );

    private static Damage BasicHeroDamage() =>
        new(
            basicFireDamage: TestHeroValues.BASIC_FIRE_HERO_DAMAGE,
            basicIceDamage: TestHeroValues.BASIC_ICE_HERO_DAMAGE,
            basicPhysicalDamage: TestHeroValues.BASIC_PHYSICAL_HERO_DAMAGE,
            basicWindDamage: TestHeroValues.BASIC_WIND_HERO_DAMAGE
        );

    private static Health NewHeroHealth() =>
        new(
            currentValue: TestHeroValues.CURRENT_HERO_HEALTH_VALUE,
            maxValue: TestHeroValues.MAX_HERO_HEALTH_VALUE
            );

    private static Health NewReducedHeroHealth() =>
    new(
        currentValue: TestHeroValues.REDUCED_CURRENT_HERO_HEALTH_VALUE,
        maxValue: TestHeroValues.MAX_HERO_HEALTH_VALUE
        );

    private static GrizaKorvoSword NewSword() =>
         new(damage: NewSwordDamage());

    private static Damage NewSwordDamage() =>
        new(
            basicPhysicalDamage: TestHeroValues.PHYSICAL_SWORD_DAMAGE,
            basicIceDamage: TestHeroValues.ICE_SWORD_DAMAGE,
            basicWindDamage: TestHeroValues.WIND_SWORD_DAMAGE,
            basicFireDamage: TestHeroValues.FIRE_SWORD_DAMAGE
            );


    private static GrizaKorvoArmor NewGrizaKorvoArmor() =>
        new(resistance: NewGrizaKorvoArmorResistance());

    private static Resistance NewGrizaKorvoArmorResistance() =>
      new(
           basicPhysicalDamageResistance: TestHeroValues.ARMOR_PHYSICAL_RESISTANCE,
           basicFireDamageResistance: TestHeroValues.ARMOR_FIRE_RESISTANCE,
           basicIceDamageResistance: TestHeroValues.ARMOR_ICE_RESISTANCE,
           basicWindDamageResistance: TestHeroValues.ARMOR_WIND_RESISTANCE
          );
}

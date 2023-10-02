public class TestHitFactory
{
    public static Hit NewSmallHitForHero() => 
        new(
            physicalDamage: TestHeroValues.BASIC_SMALL_PHYSICAL_NPC_DAMAGE,
            iceDamage: TestHeroValues.BASIC_SMALL_ICE_NPC_DAMAGE,
            fireDamage: TestHeroValues.BASIC_SMALL_FIRE_NPC_DAMAGE,
            windDamage: TestHeroValues.BASIC_SMALL_WIND_NPC_DAMAGE
            );

    public static Hit NewLargeHitForHero() =>
      new(
          physicalDamage: TestHeroValues.BASIC_LARGE_PHYSICAL_NPC_DAMAGE,
          iceDamage: TestHeroValues.BASIC_LARGE_ICE_NPC_DAMAGE,
          fireDamage: TestHeroValues.BASIC_LARGE_FIRE_NPC_DAMAGE,
          windDamage: TestHeroValues.BASIC_LARGE_WIND_NPC_DAMAGE
          );
}

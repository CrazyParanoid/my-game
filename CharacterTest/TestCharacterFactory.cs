
namespace CharacterTest
{
    internal class TestCharacterFactory
    {

        public static Hero NewHero()
        {
            return new Hero(NewHealth(), NewCharacteristics());
        }

        private static Characteristics NewCharacteristics()
        {
            return new Characteristics(
                strength: TestValues.STRENGHT,
                dexterity: TestValues.DEXTERITY,
                intelligence: TestValues.INTELLIGENCE,
                damage: TestValues.DAMAGE);
        }

        private static Health NewHealth()
        {
            return new Health(
                currentValue: TestValues.CURRENT_HEALTH_VALUE,
                maxValue: TestValues.MAX_HEALTH_VALUE);
        }
    }
}

namespace CharacterTest
{
    public class CharacterTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            Hero hero = TestCharacterFactory.NewHero();
        }
    }
}
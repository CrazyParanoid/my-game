public class TestItemsFactory
{
    public static HealthPotion NewHealthPotion() =>
        new(
            value: TestItemsValues.HEALTH_POTION_VALUE
        );
}

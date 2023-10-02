public class TestPersonFactory
{
    public static Person NewPerson() => new(dialog: TestDialogFactory.NewDialog());
}

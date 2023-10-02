using NUnit.Framework;

public class PersonTest
{

    [Test]
    public void ShouldStartDialog()
    {
        var person = TestPersonFactory.NewPerson();

        var defaultDialogVariant = person.StartDialog;

        Assert.AreEqual(defaultDialogVariant.AnswerId, 0);
        Assert.AreEqual(defaultDialogVariant.Text, TestDialogValues.DEFAULT_DIALOG_VARIANT_TEXT);
        Assert.AreEqual(defaultDialogVariant.Probability(), TestDialogValues.DEFAULT_DIALOG_VARIANT_PROBABILITY);

        AssertAnswer1(defaultDialogVariant.Answers[0]);
        AssertAnswer2(defaultDialogVariant.Answers[1]);
        AssertAnswer3(defaultDialogVariant.Answers[2]);
    }

    private void AssertAnswer1(Answer answer)
    {
        Assert.AreEqual(answer.Id, TestDialogValues.ANSWER_1_ID);
        Assert.AreEqual(answer.Text, TestDialogValues.ANSWER_1_TEXT);
    }
    private void AssertAnswer2(Answer answer)
    {
        Assert.AreEqual(answer.Id, TestDialogValues.ANSWER_2_ID);
        Assert.AreEqual(answer.Text, TestDialogValues.ANSWER_2_TEXT);
    }

    private void AssertAnswer3(Answer answer)
    {
        Assert.AreEqual(answer.Id, TestDialogValues.ANSWER_3_ID);
        Assert.AreEqual(answer.Text, TestDialogValues.ANSWER_3_TEXT);
    }

    [Test]
    public void ShouldTakeAnswer1()
    {
        var person = TestPersonFactory.NewPerson();
        _ = person.StartDialog;

        var variant = person.TakeAnswer(
            TestDialogValues.ANSWER_1_ID,
            TestHeroValues.HERO_INTELLIGENCE
            );

        Assert.IsNull(variant.Answers);
        Assert.AreEqual(variant.AnswerId, TestDialogValues.ANSWER_1_ID);
        Assert.AreEqual(variant.Text, TestDialogValues.VARIANT_1_TEXT);
        Assert.AreEqual(variant.Probability(), TestDialogValues.DEFAULT_DIALOG_VARIANT_PROBABILITY);
    }

    [Test]
    public void ShouldTakeAnswer2()
    {
        var person = TestPersonFactory.NewPerson();
        _ = person.StartDialog;

        var variant = person.TakeAnswer(
            TestDialogValues.ANSWER_2_ID,
            TestHeroValues.HERO_INTELLIGENCE
            );

        Assert.IsNull(variant.Answers);
        Assert.AreEqual(variant.AnswerId, TestDialogValues.ANSWER_2_ID);
        Assert.AreEqual(variant.Text, TestDialogValues.VARIANT_2_TEXT);
        Assert.AreEqual(variant.Probability(), TestDialogValues.DEFAULT_DIALOG_VARIANT_PROBABILITY);
    }

    [Test]
    public void ShouldTakeAnswer4WithLargeIntelligence()
    {
        var person = TestPersonFactory.NewPerson();
        _ = person.StartDialog;

        var variant = person.TakeAnswer(
            TestDialogValues.ANSWER_3_ID_4,
            TestHeroValues.HERO_LARGE_INTELLIGENCE
            );

        Assert.IsNull(variant.Answers);
        Assert.AreEqual(variant.AnswerId, TestDialogValues.ANSWER_3_ID_4);
        Assert.AreEqual(variant.Text, TestDialogValues.VARIANT_6_TEXT);
        Assert.AreEqual(variant.Probability(), TestDialogValues.VARIANT_6_PROBABILITY);
    }

    [Test]
    public void ShouldBackToDefaultVarinatIfAnswerIdEqualsZero()
    {
        var person = TestPersonFactory.NewPerson();
        _ = person.StartDialog;

        var variant = person.TakeAnswer(0, TestHeroValues.HERO_INTELLIGENCE);

        Assert.AreEqual(variant.AnswerId, 0);
    }
}

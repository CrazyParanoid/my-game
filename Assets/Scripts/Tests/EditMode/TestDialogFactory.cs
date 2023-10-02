using System.Collections.Generic;

public class TestDialogFactory
{
    public static Dialog NewDialog() =>
        new(
            defaultVariant: NewDefaultVariant(),
            variants: new()
            {
                NewVariant1(), NewVariant2(),
                NewVariant3(), NewVariant4(),
                NewVariant5(), NewVariant6()
            },
            currentVariant: NewDefaultVariant()
            );

    private static Variant NewDefaultVariant() =>
        new (
            answerId: 0,
            text: TestDialogValues.DEFAULT_DIALOG_VARIANT_TEXT,
            probability: TestDialogValues.DEFAULT_DIALOG_VARIANT_PROBABILITY,
            answers: NewDefaultAnswers()
            );

    private static List<Answer> NewDefaultAnswers()
    {
        return new()
        {
              NewAnswer1(),
              NewAnswer2(),
              NewAnswer3()
        };
    }

    public static Answer NewAnswer1() =>
        new(
            text: TestDialogValues.ANSWER_1_TEXT,
            id: TestDialogValues.ANSWER_1_ID
            );

    public static Answer NewAnswer2() =>
        new(
            text: TestDialogValues.ANSWER_2_TEXT,
            id: TestDialogValues.ANSWER_2_ID
            );

    public static Answer NewAnswer3() =>
        new(
            text: TestDialogValues.ANSWER_3_TEXT,
            id: TestDialogValues.ANSWER_3_ID
            );

    public static Answer NewAnswer3_4() =>
        new(
            text: TestDialogValues.ANSWER_3_TEXT_4,
            id: TestDialogValues.ANSWER_3_ID_4
            );

    private static Variant NewVariant1() =>
        new(
            answerId: TestDialogValues.ANSWER_1_ID,
            text: TestDialogValues.VARIANT_1_TEXT,
            probability: TestDialogValues.DEFAULT_DIALOG_VARIANT_PROBABILITY,
            answers: null
            );

    private static Variant NewVariant2() =>
        new(
            answerId: TestDialogValues.ANSWER_2_ID,
            text: TestDialogValues.VARIANT_2_TEXT,
            probability: TestDialogValues.DEFAULT_DIALOG_VARIANT_PROBABILITY,
            answers: null
            );

    private static Variant NewVariant3() =>
        new(
            answerId: TestDialogValues.ANSWER_3_ID,
            text: TestDialogValues.VARIANT_3_TEXT,
            probability: TestDialogValues.DEFAULT_DIALOG_VARIANT_PROBABILITY,
            answers: null
            );

    private static Variant NewVariant4() =>
        new(
            answerId: TestDialogValues.ANSWER_4_ID,
            text: TestDialogValues.VARIANT_4_TEXT,
            probability: TestDialogValues.DEFAULT_DIALOG_VARIANT_PROBABILITY,
            answers: NewVariant4Answers()
            );

    private static List<Answer> NewVariant4Answers()
    {
        return new()
        {
              new Answer(text: TestDialogValues.ANSWER_1_TEXT_4, id: TestDialogValues.ANSWER_1_ID_4),
              new Answer(text: TestDialogValues.ANSWER_2_TEXT_4, id: TestDialogValues.ANSWER_2_ID_4),
              new Answer(text: TestDialogValues.ANSWER_3_TEXT_4, id: TestDialogValues.ANSWER_3_ID_4)
        };
    }

    private static Variant NewVariant5() =>
        new(
            answerId: TestDialogValues.ANSWER_3_ID_4,
            text: TestDialogValues.VARIANT_5_TEXT,
            probability: TestDialogValues.VARIANT_5_PROBABILITY,
            answers: null
            );

    private static Variant NewVariant6() =>
        new(
            answerId: TestDialogValues.ANSWER_3_ID_4,
            text: TestDialogValues.VARIANT_6_TEXT,
            probability: TestDialogValues.VARIANT_6_PROBABILITY,
            answers: null
            );
}

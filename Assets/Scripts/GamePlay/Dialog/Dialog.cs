using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog", fileName = "Dialog")]
public class Dialog : ScriptableObject
{
    [SerializeField]
    private List<Variant> variants;

    [SerializeField]
    private Variant currentVariant;

    [SerializeField]
    private Variant defaultVariant;

    public Dialog(List<Variant> variants, Variant currentVariant, Variant defaultVariant)
    {
        this.variants = variants;
        this.currentVariant = currentVariant;
        this.defaultVariant = defaultVariant;
    }

    public Variant TakeAnswer(int answerId, float intelligence)
    {
        if(answerId == 0)
        {
            return BackToDefaultVariant();
        }
        var foundVariants = variants.FindAll(variant => variant.AnswerId == answerId);

        if (foundVariants.Count > 1)
        {
            currentVariant = ChanceUtil.TakeRandomByChance(foundVariants, intelligence);
        }
        else
        {
            currentVariant = foundVariants.First();
        }

        return currentVariant;
    }

    public Variant BackToDefaultVariant()
    {
        currentVariant = defaultVariant;
        return defaultVariant;
    }

    public Variant Start() => defaultVariant;

    public Variant CurrentVariant
    {
        get { return currentVariant; }
    }

    public string CurrentVariantText
    {
        get { return currentVariant.Text; }
    }

    public List<Answer> ShowCurrentAnswers() => currentVariant.Answers;
}

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variant", fileName = "Variant")]
public class Variant : ScriptableObject, IWithProbability
{
    [SerializeField]
    private int answerId;

    [SerializeField]
    private string text;

    [SerializeField]
    protected float probability;

    [SerializeField]
    private List<Answer> answers;

    public Variant(int answerId, string text, float probability, List<Answer> answers)
    {
        this.answerId = answerId;
        this.text = text;
        this.probability = probability;
        this.answers = answers;
    }

    public int AnswerId
    {
        get { return answerId; }
    }

    public string Text
    {
        get { return text; }
    }

    public List<Answer> Answers
    {
        get { return answers; }
    }

    public float Probability()
    {
        return probability;
    }
}

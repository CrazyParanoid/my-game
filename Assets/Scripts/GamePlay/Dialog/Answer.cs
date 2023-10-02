using UnityEngine;

[CreateAssetMenu(menuName = "Answer", fileName = "Answer")]
public class Answer: ScriptableObject
{
    [SerializeField]
    private string text;
    [SerializeField]
    private int id;

    public Answer(string text, int id)
    {
        this.text = text;
        this.id = id;
    }

    public string Text
    {
        get { return text; }
    }

    public int Id
    {
        get { return id; }
    }
}

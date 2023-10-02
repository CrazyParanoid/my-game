using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnswersWindow : MonoBehaviour
{
    private List<DialogAnswer> dialogAnswers;

    private void Awake()
    {
        dialogAnswers = GetComponentsInChildren<DialogAnswer>().ToList();
    }

    public void InitAnswers(List<Answer> answers)
    {
        for (int i = 0; i < answers.Count; i++)
        {
            var dialogAnswer = dialogAnswers[i];
            dialogAnswer.SetTextValue(answers[i].Text);
            dialogAnswer.Id = answers[i].Id;
        }
    }

    public void ClearAnswers()
    {
        foreach (var answer in dialogAnswers)
        {
            answer.Clear();
        }
    }
}

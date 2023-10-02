using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fullHealthLine;
    public Image emptyHealthLine;

    public void OnHealthReducedByDamage(float value)
    {
        if (fullHealthLine != null)
        {
            fullHealthLine.fillAmount = value / 100;
        }
    }

    public void Disable()
    {
        fullHealthLine.gameObject.SetActive(false);
        emptyHealthLine.gameObject.SetActive(false);
    }

    public void Enable()
    {
        fullHealthLine.gameObject.SetActive(true);
        emptyHealthLine.gameObject.SetActive(true);
    }
}

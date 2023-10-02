using UnityEngine;

public class HeroSwitcher : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject gameObject = GameObject.Find("artorias");
            gameObject.SetActive(false);
        }

    }
}

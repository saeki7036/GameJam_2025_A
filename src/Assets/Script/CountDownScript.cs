using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    [SerializeField] Text TimerText;
    float limitTime = 60;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        limitTime -= Time.deltaTime;

        if (limitTime <= 0)
        {
            limitTime = 0;
        }

        TimerText.text = limitTime.ToString("F0");
    }
}

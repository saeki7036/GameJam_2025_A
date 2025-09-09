using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    [SerializeField] Text TimerText;
    [SerializeField] float limitTime = 60;

    [SerializeField]  bool IscountDown = false;

    [SerializeField] UnityEvent UnityEvent;

    public void SetCountdown() => IscountDown = true;

    public float GetlimitTime => limitTime;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IscountDown)
            return;

        limitTime -= Time.fixedDeltaTime;

        if (limitTime <= 0)
        {
            limitTime = 0;

            IscountDown = false;

            UnityEvent.Invoke();
        }

        TimerText.text = limitTime.ToString("F0");
    }
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainGameUIController : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Image image;


    [SerializeField] float MaxWidth = 1290f;
    [SerializeField] float MaxHeight = 840f;

    [SerializeField] float ScaleUPCount = 3f;
    [SerializeField] float FadeOutCount = 1f;

    [SerializeField] UnityEvent unityEvent;

    [SerializeField] bool IsScaleUP;

    [SerializeField] bool IsControll = true;

    float TimeCount;

    bool IsFadeOut;

    public void StartControll() 
    {
        IsScaleUP = true;
        IsControll = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimeCount = 0;
        IsFadeOut = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsControll) return;

        TimeCount += Time.fixedDeltaTime;

        if (IsScaleUP)
        {
            // 0`1 ‚Ì•âŠÔŒW”
            float t = Mathf.Clamp01(TimeCount / ScaleUPCount);

            // ƒTƒCƒY‚ð•âŠÔ‚µ‚Ä•ÏX
            rectTransform.sizeDelta = new Vector2(MaxWidth * t, MaxHeight * t);

            if(t >= 1)
            {
                IsScaleUP = false;
                IsFadeOut = true;
                TimeCount = 0;
            }
        }
        else if (IsFadeOut)
        {
            // 0`1 ‚Ì•âŠÔŒW”
            float t = Mathf.Clamp01(TimeCount / FadeOutCount);

            var color = image.color;

            color.a = 1 - t;

            image.color = color;

            if (t >= 1)
            {
                IsFadeOut = false;
                TimeCount = 0;
                unityEvent.Invoke();

                IsControll = false;
            }
        }
    }
}

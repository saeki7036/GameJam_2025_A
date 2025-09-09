using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class MainGameUIController : MonoBehaviour
{
    [SerializeField] float MaxWidth = 1290f;
    [SerializeField] float MaxHeight = 840f;

    [SerializeField] float ScaleUPCount = 3f;
    [SerializeField] float FedeOutCount = 1f;

    [SerializeField] UnityEvent unityEvent;

    float TimeCount;

    bool IsScaleUP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TimeCount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeCount += Time.fixedDeltaTime;
        //if()

        unityEvent.Invoke();
    }
}

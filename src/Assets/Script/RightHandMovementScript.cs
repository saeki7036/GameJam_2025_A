using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class RightHandMovementScript : MonoBehaviour
{
    int rindex;
    int rposition = 2;
    [SerializeField] int DefaltOrderLayer = 0;
    [SerializeField] int CloseOrderLayer = 10;
    [SerializeField] Sprite DefaltSprite;
    [SerializeField] Sprite CloseSprite;
    [SerializeField] Sprite OpenSprite;
    [SerializeField] SpriteRenderer spriteRenderer;
    [Space]
    [SerializeField] float Closeduration = 0.3f;
    [SerializeField] Transform CloseHandTransform;
    [Space]
    [SerializeField] AudioClip moveClip;
    [SerializeField] AudioSource SEsource;
    [Space]
    [SerializeField] Transform[] rPosition;
    bool IsInputRight, IsCloseHand;

    public int GetRpositionPoint => rposition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsInputRight = true;
        IsCloseHand = false;
        rindex = 0;
        /*
                Vector2 RP0 = rPosition[0].position;
                RP0 = new Vector2(0, 4);
                rPosition[0].position = RP0;
                Vector2 RR0 = rPosition[0].eulerAngles;
                RR0 = new Vector3(0, 0, 90);
                rPosition[0].eulerAngles = RR0;
                Vector2 RP1 = rPosition[1].position;
                RP1 = new Vector2(2.8f, 2.8f);
                rPosition[1].position = RP1;
                Vector2 RR1 = rPosition[1].eulerAngles;
                RR1 = new Vector3(0, 0, 45);
                rPosition[1].eulerAngles = RR1;
                Vector2 RP2 = rPosition[2].position;
                RP2 = new Vector2(4, 0);
                rPosition[2].position = RP2;
                Vector2 RR2 = rPosition[2].eulerAngles;
                RR2 = new Vector3(0, 0, 0);
                rPosition[2].eulerAngles = RR2;
                Vector2 RP3 = rPosition[3].position;
                RP3 = new Vector2(2.8f, -2.8f);
                rPosition[3].position = RP3;
                Vector2 RR3 = rPosition[3].eulerAngles;
                RR3 = new Vector3(0, 0, -45);
                rPosition[3].eulerAngles = RR3;
                Vector2 RP4 = rPosition[4].position;
                RP4 = new Vector2(0, -4);
                rPosition[4].position = RP4;
                Vector2 RR4 = rPosition[4].eulerAngles;
                RR4 = new Vector3(0, 0, -90);
                rPosition[4].eulerAngles = RR4;*/
        transform.position = rPosition[rposition].position;
    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null || IsCloseHand)
        {
            return;
        }

        var rightStick = gamepad.rightStick.y.ReadValue();

        //Debug.Log(leftStick + " " + rightStick);
        if (IsInputRight)
        {
            if (rightStick >= 0.7)
            {
                rindex = 1;
            }
            if (rightStick <= -0.7)
            {
                rindex = -1;
            }
        }

        if (rindex != 0)
        {
            if (rightStick <= 0.2 && rightStick >= -0.2)
            {
                rindex = 0; IsInputRight = true;
            }
        }

        if (IsInputRight)
        {
            if (rindex == 1)
            {
                rposition -= 1;
                if (rposition < 0)
                {
                    rposition = 0;
                }

                transform.position = rPosition[rposition].position;
                transform.eulerAngles = rPosition[rposition].eulerAngles;

                IsInputRight = false;

                SEsource.PlayOneShot(moveClip);
            }
            if (rindex == -1)
            {
                rposition += 1;
                if (rposition >= rPosition.Length)
                {
                    rposition = rPosition.Length -1;
                }

                transform.position = rPosition[rposition].position;
                transform.eulerAngles = rPosition[rposition].eulerAngles;

                IsInputRight = false;

                SEsource.PlayOneShot(moveClip);
            }
        }
    }

    public void CloseHand() => StartCoroutine(CloseRightHand());

    IEnumerator CloseRightHand()
    {
        Vector2 StartPos = transform.position;
        Vector2 EndPos = CloseHandTransform.position;
        IsCloseHand = true;

        // çsÇ´
        spriteRenderer.sprite = CloseSprite;
        spriteRenderer.sortingOrder = CloseOrderLayer;

        float elapsed = 0f;
        while (elapsed < Closeduration)
        {
            elapsed += Time.fixedDeltaTime;
            float t = Mathf.Clamp01(elapsed / Closeduration);
            transform.position = Vector3.Lerp(StartPos, EndPos, t);
            yield return new WaitForFixedUpdate(); // Å© ï®óùçèÇ›Ç…ìØä˙
        }

        // ñﬂÇË
        spriteRenderer.sprite = OpenSprite;
        elapsed = 0f;
        while (elapsed < Closeduration)
        {
            elapsed += Time.fixedDeltaTime;
            float t = Mathf.Clamp01(elapsed / Closeduration);
            transform.position = Vector3.Lerp(EndPos, StartPos, t);
            yield return new WaitForFixedUpdate(); // Å© ï®óùçèÇ›Ç…ìØä˙
        }

        // èàóùèIóπ
        spriteRenderer.sprite = DefaltSprite;
        spriteRenderer.sortingOrder = DefaltOrderLayer;
        IsCloseHand = false;
    }
}
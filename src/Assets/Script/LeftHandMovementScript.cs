using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class LeftHandMovementScript : MonoBehaviour
{
    int lindex;
    int lposition = 2;

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
    [SerializeField] Transform[] lPosition;
    bool IsInputLeft, IsCloseHand;

    public int GetLpositionPoint => lposition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsInputLeft = true;
        IsCloseHand = false;
        lindex = 0;

        transform.position = lPosition[lposition].position;
    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null || IsCloseHand)
        {
            return;
        }

        var leftStick = gamepad.leftStick.y.ReadValue();
        //var rightStick = gamepad.rightStick.y.ReadValue();
        Debug.Log(leftStick);
        //Debug.Log(leftStick + " " + rightStick);
        if (IsInputLeft)
        {
            if (leftStick >= 0.7)
            {
                lindex = 1;
            }
            if (leftStick <= -0.7)
            {
                lindex = -1;
            }
        }

        if (lindex != 0)
        {
            if (leftStick <= 0.2 && leftStick >= -0.2)
            {
                lindex = 0; IsInputLeft = true;
            }
        }

        if (IsInputLeft)
        {
            if (lindex == 1)
            {
                lposition -= 1;
                if (lposition < 0)
                {
                    lposition = 0;
                }

                transform.position = lPosition[lposition].position;
                transform.eulerAngles = lPosition[lposition].eulerAngles;

                IsInputLeft = false;

                SEsource.PlayOneShot(moveClip);
            }
            if (lindex == -1)
            {
                lposition += 1;
                if (lposition >= lPosition.Length)
                {
                    lposition = lPosition.Length -1;
                }

                transform.position = lPosition[lposition].position;
                transform.eulerAngles = lPosition[lposition].eulerAngles;

                IsInputLeft = false;

                SEsource.PlayOneShot(moveClip);
            }
        }
    }

    public void CloseHand() => StartCoroutine(CloseLeftHand());
    IEnumerator CloseLeftHand()
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

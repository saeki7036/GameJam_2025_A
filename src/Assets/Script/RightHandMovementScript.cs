using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class RightHandMovementScript : MonoBehaviour
{
    int rindex;
    int rposition = 2;
    [SerializeField] Transform[] rPosition;
    bool IsInputRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsInputRight = true;

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
        if (gamepad == null)
        {
            return;
        }

        var leftStick = gamepad.leftStick.y.ReadValue();
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
            }
            if (rindex == -1)
            {
                rposition += 1;
                if (rposition > 5)
                {
                    rposition = 5;
                }

                transform.position = rPosition[rposition].position;
                transform.eulerAngles = rPosition[rposition].eulerAngles;

                IsInputRight = false;
            }
        }
    }
}
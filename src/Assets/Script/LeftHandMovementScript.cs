using UnityEngine;
using UnityEngine.InputSystem;

public class LeftHandMovementScript : MonoBehaviour
{
    int lindex;
    int lposition = 2;
    [SerializeField] Transform[] lPosition;
    bool IsInputLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsInputLeft = true;

        lindex = 0;

        transform.position = lPosition[lposition].position;
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
            }
            if (lindex == -1)
            {
                lposition += 1;
                if (lposition > 5)
                {
                    lposition = 5;
                }

                transform.position = lPosition[lposition].position;
                transform.eulerAngles = lPosition[lposition].eulerAngles;

                IsInputLeft = false;
            }
        }
    }
}

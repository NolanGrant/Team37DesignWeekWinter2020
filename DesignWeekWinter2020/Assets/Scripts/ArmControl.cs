using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControl : MonoBehaviour
{
    public float horiAxis;
    public float vertAxis;

    public int playerid;
    public Rigidbody2D targetHand;
    public float TargetHandMovementForce = 5f;

    public float TargetHandRotationForce = 5f;

    Vector2 inputDirection;

    public bool stopMovingIfNoInput = true;


    string horizontalInputName;
    string verticalInputName;

    // Start is called before the first frame update
    void Start()
    {
        //assign input names
         horizontalInputName = playerid.ToString() + "_Horizontal";
         verticalInputName = playerid.ToString() + "_Vertical"; ;
    }

    // Update is called once per frame
    void Update()
    {
        inputDirection = (new Vector2(horiAxis, vertAxis)).normalized;
    }

    private void FixedUpdate()
    {

        if(stopMovingIfNoInput == true)
        {
            targetHand.velocity = (inputDirection * TargetHandMovementForce);
        }
        else
        {
            if (inputDirection.magnitude > 0.1f)
            {
                targetHand.velocity = (inputDirection * TargetHandMovementForce);
            }
        }

        if( inputDirection.magnitude > 0.1f)
        {
            targetHand.angularVelocity = 0f;
        }

        /*
        if (Input.GetButton("Fire1"))
        {
            print("fire1");
            targetHand.angularVelocity = TargetHandRotationForce;
        }
        else if (Input.GetButton("Fire2"))
        {
            print("fire2");
            targetHand.angularVelocity = -TargetHandRotationForce;
        }
        */

    }
}

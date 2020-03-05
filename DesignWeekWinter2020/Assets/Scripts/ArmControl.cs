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
    public ArmHealth myHealth;
    string horizontalInputName;
    string verticalInputName;

    private void Awake()
    {
        myHealth = GetComponent<ArmHealth>();
    }

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
        
    }

    private void FixedUpdate()
    {
        inputDirection = (new Vector2(horiAxis, vertAxis)).normalized;

        if (myHealth.destroyed == false)
        {
            targetHand.velocity = (inputDirection * TargetHandMovementForce);
        }
        else
        {
            targetHand.velocity = Vector2.zero;
        }

        if (inputDirection.magnitude > 0.1f)
        {
            targetHand.angularVelocity = 0f;
        }


        horiAxis = 0;
        vertAxis = 0;

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

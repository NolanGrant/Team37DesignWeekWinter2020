using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerid;

    float deltaX;
    float deltaY;
    Rigidbody2D _body;

    public GameObject leftGun;
    public GameObject rightGun;
    public GameObject ship;

    public Color baseColor;
    public Color hoverColor;
    public Color dockedColor;

    public float speed;

    private bool dockAttempt = false;
    private bool docked = false;

    GameObject currentGun;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dockAttempt = false;
        deltaX = Input.GetAxis(playerid + "_Horizontal");
        deltaY = Input.GetAxis(playerid + "_Vertical");

        Vector2 inputVec = new Vector2(deltaX, deltaY).normalized;
        /*
        if (Input.GetKey(KeyCode.A))
        {
            deltaX = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            deltaX = speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            deltaY = speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            deltaY = -speed;
        }
        */
        if (Input.GetButtonDown(playerid + "_Action"))
        {
            dockAttempt = true;
        }
        

        //float velx = _body.velocity.x;
        //velx = deltaX - velx;
        //float vely = _body.velocity.y;
        //vely = deltaY - vely;
        _body.velocity = inputVec * speed;

        if (docked)
        {
            /*
            currentGun.transform.RotateAround(ship.transform.position, new Vector3(0,0,1), -0.5f * Input.GetAxis(playerid + "_Horizontal"));
            //currentGun.transform.Translate(new Vector3(-1,0,0));
            if (Input.GetButtonDown(playerid + "_Shoot"))
            {
                currentGun.GetComponent<Guns>().triggerShoot = true;
            }
            */
            currentGun.GetComponent<ArmControl>().horiAxis = Input.GetAxis(playerid + "_Horizontal");
            currentGun.GetComponent<ArmControl>().vertAxis = Input.GetAxis(playerid + "_Vertical");
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject checkCollision = collision.gameObject;

        ControlConsole console = checkCollision.GetComponent<ControlConsole>();

        if(console != null)
        {
            //collision.gameObject.GetComponent<SpriteRenderer>().color = hoverColor;

            if (dockAttempt && !docked)
            {
                docked = true;
                transform.position = collision.transform.position;
                _body.velocity = new Vector2(0, 0);
                dockAttempt = false;
                currentGun = console.curArm;
            }

            if (docked)
            {
                //collision.gameObject.GetComponent<SpriteRenderer>().color = dockedColor;
                transform.position = collision.transform.position;
                _body.velocity = new Vector2(0, 0);
                if (dockAttempt)
                {
                    docked = false;
                    transform.position = new Vector3(collision.transform.position.x + 0.2f, collision.transform.position.y, transform.position.z);
                }
            }
        }
        
    }
}

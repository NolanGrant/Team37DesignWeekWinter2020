using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    float deltaX;
    float deltaY;
    Rigidbody2D _body;

    public GameObject leftGun;
    public GameObject rightGun;

    public Color baseColor;
    public Color hoverColor;
    public Color dockedColor;

    public float speed;

    private bool dockAttempt = false;
    private bool docked = false;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dockAttempt = false;
        deltaX = 0;
        deltaY = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            deltaX = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            deltaX = speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            deltaY = speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            deltaY = -speed;
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            dockAttempt = true;
        }

        float velx = _body.velocity.x;
        velx = deltaX - velx;
        float vely = _body.velocity.y;
        vely = deltaY - vely;
        _body.AddForce(new Vector2(velx, vely));
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collide");
        GameObject checkCollision = collision.gameObject;

        LeftGun leftDock = checkCollision.GetComponent<LeftGun>();

        RightGun rightDock = checkCollision.GetComponent<RightGun>();

        if (leftDock != null)
        {
            Debug.Log("Collide");
            //collision.gameObject.GetComponent<SpriteRenderer>().color = hoverColor;

            if (dockAttempt && !docked)
            {
                Debug.Log("Dock");
                docked = true;
                transform.position = collision.transform.position;
                _body.velocity = new Vector2(0, 0);
                dockAttempt = false;
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
        if (rightDock != null)
        {
            Debug.Log("Collide");
            //collision.gameObject.GetComponent<SpriteRenderer>().color = hoverColor;

            if (dockAttempt && !docked)
            {
                Debug.Log("Dock");
                docked = true;
                transform.position = collision.transform.position;
                _body.velocity = new Vector2(0, 0);
                dockAttempt = false;
            }

            if (docked)
            {
                //collision.gameObject.GetComponent<SpriteRenderer>().color = dockedColor;
                transform.position = collision.transform.position;
                _body.velocity = new Vector2(0, 0);
                if (dockAttempt)
                {
                    docked = false;
                    transform.position = new Vector3(collision.transform.position.x - 0.2f, collision.transform.position.y, transform.position.z);
                }
            }
        }
    }
}

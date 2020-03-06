using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float movement = 0;
    public float speed;
    Rigidbody2D _body;

    public GameObject leftThruster;
    public GameObject rightThruster;

    public float resetRate = 0.5f;

    public float maxHorizontalMovement;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _body.velocity = new Vector2(0, 0);
        _body.velocity = transform.right * movement * speed;

        if (movement > 0.1f)
        {
            leftThruster.SetActive(true);
            rightThruster.SetActive(false);
        }
        else if (movement < -0.1f)
        {
            rightThruster.SetActive(true);
            leftThruster.SetActive(false);
        }
        else
        {
            _body.position = new Vector2(_body.position.x * (1 - (resetRate * Time.deltaTime)), _body.position.y);

            rightThruster.SetActive(false);
            leftThruster.SetActive(false);
        }

        movement = 0;

    }
    private void LateUpdate()
    {
        _body.position = new Vector2(Mathf.Clamp(_body.position.x, -maxHorizontalMovement, maxHorizontalMovement), _body.position.y);
    }
    private void FixedUpdate()
    {
        _body.position = new Vector2(Mathf.Clamp(_body.position.x, -maxHorizontalMovement, maxHorizontalMovement), _body.position.y);
    }
}


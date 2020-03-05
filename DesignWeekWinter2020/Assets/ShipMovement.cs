using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float movement = 0;
    public float speed;
    Rigidbody2D _body;
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

        movement = 0;
    }
}

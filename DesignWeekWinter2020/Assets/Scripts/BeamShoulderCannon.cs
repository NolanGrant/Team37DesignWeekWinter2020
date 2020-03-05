using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamShoulderCannon : MonoBehaviour
{
    SpriteRenderer sr;

    public float fliptime = 0.1f;
    float flipTimer;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        flipTimer += Time.deltaTime;

        if(sr.flipX == true && flipTimer > fliptime)
        {
            flipTimer = 0;
            sr.flipX = false;
        }

        else if (sr.flipX == false && flipTimer > fliptime)
        {
            flipTimer = 0;
            sr.flipX = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject checkCollision = collision.gameObject;

        Enemy curEnemy = checkCollision.GetComponent<Enemy>();

        if (curEnemy != null)
        {
            curEnemy.hp -= 2;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    [SerializeField]
    float chargeTime = 0.75f;

    [SerializeField]
    bool zigzag = true;

    [SerializeField]
    bool forward = false;

    [SerializeField]
    bool chargeAttack = false;

    public GameObject explosionPrefab;
    public GameObject scorePop;

    //private WaveSetUp Spawner;

    Vector3 startingPos;

    private Transform EndPoint;

    private float MaxMovementSpeed;

    [FMODUnity.EventRef]
    public string screamEvent = "";
    FMOD.Studio.EventInstance scream;
    // Start is called before the first frame update
    void Start()
    {

        startingPos = transform.position;
        EndPoint = GameObject.Find("EndPoint").transform;
        //Spawner = GameObject.Find("Spawner").GetComponent<WaveSetUp>();
        //Spawner.IncreaseAliveEnemies();

        scream = FMODUnity.RuntimeManager.CreateInstance(screamEvent);
    }

    private void Awake()
    {
        if (chargeAttack)
        {
            MaxMovementSpeed = movementSpeed;
            movementSpeed = 0;
            StartCoroutine(WaitToCharge());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //MoveDown();
        CheckOutOfBounds();
    }
    void MoveDown()
    {

        if (zigzag)
        {
            startingPos -= transform.up * Time.deltaTime * movementSpeed;
            transform.position = startingPos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
        }

        else if (forward)
        {
            startingPos -= transform.up * Time.deltaTime * movementSpeed;
            transform.position = startingPos + transform.right * magnitude;
        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Kill();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("EnemyCollider"))
        {

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            MainHealth.hp -= 5;

            //Spawner.DecreaseAliveEnemies();
            Destroy(this.gameObject);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("LeftWeapon") || collision.gameObject.layer == LayerMask.NameToLayer("RightWeapon"))
        {
            Kill();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("LeftArm") || collision.gameObject.layer == LayerMask.NameToLayer("RightArm"))
        {
            Kill();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("OnlyInteractEnemies"))
        {
            Kill();
        }
    }

    void Kill()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameObject score = GameObject.Instantiate(scorePop, transform.position, Quaternion.identity) as GameObject;
        score.GetComponent<RectTransform>().position = transform.position;
        score.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        score.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        Score.score += 50;
        //Spawner.DecreaseAliveEnemies();
        Destroy(this.gameObject);
    }

    private void CheckOutOfBounds() 
    {
        if(EndPoint == null)
        {
            Debug.Log("ENDPOINT NOT SET");
        }
        else if (transform.position.y < EndPoint.position.y)
        {
            MainHealth.hp -= 5;
            //scream.start();
            Destroy(this.gameObject);
            //Spawner.DecreaseAliveEnemies();
        }
    
    }

    private IEnumerator WaitToCharge()
    { 
        yield return new WaitForSeconds(chargeTime);
        movementSpeed = MaxMovementSpeed;
    }

    
}

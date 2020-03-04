using System.Collections;
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
    bool zigzag = true;

    [SerializeField]
    bool forward = false;

    public GameObject explosionPrefab;

    private WaveSetUp Spawner;

    Vector3 startingPos;

    private Transform EndPoint;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        Spawner = GameObject.Find("Spawner").GetComponent<WaveSetUp>();
        Spawner.IncreaseAliveEnemies();
        EndPoint = GameObject.Find("EndPoint").transform;

    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
        CheckOutOfBounds();
    }
    void MoveDown()
    {
        if (zigzag)
        {
            startingPos -= transform.up * Time.deltaTime * movementSpeed;
            transform.position = startingPos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
        }

        if (forward)
        {
            startingPos -= transform.up * Time.deltaTime * movementSpeed;
            transform.position = startingPos + transform.right * magnitude;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Spawner.DecreaseAliveEnemies();
        Destroy(this.gameObject);
    }

    private void CheckOutOfBounds() 
    {
        if (transform.position.y < EndPoint.position.y)
        {
            Destroy(this.gameObject);
            Spawner.DecreaseAliveEnemies();
        }
    
    }

    
}

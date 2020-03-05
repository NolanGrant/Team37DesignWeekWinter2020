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
    float chargeTime = 0.75f;

    [SerializeField]
    bool zigzag = true;

    [SerializeField]
    bool forward = false;

    [SerializeField]
    bool chargeAttack = false;

    public GameObject explosionPrefab;
    public GameObject scorePop;

    private WaveSetUp Spawner;

    Vector3 startingPos;

    private Transform EndPoint;

    private float MaxMovementSpeed;

    
    // Start is called before the first frame update
    void Start()
    {

        startingPos = transform.position;
        Spawner = GameObject.Find("Spawner").GetComponent<WaveSetUp>();
        Spawner.IncreaseAliveEnemies();
        EndPoint = GameObject.Find("EndPoint").transform;



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

        else if (forward)
        {
            startingPos -= transform.up * Time.deltaTime * movementSpeed;
            transform.position = startingPos + transform.right * magnitude;
        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameObject score = GameObject.Instantiate(scorePop, transform.position, Quaternion.identity) as GameObject;
        score.GetComponent<RectTransform>().position = transform.position;
        score.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        score.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        Score.score += 50;
        Spawner.DecreaseAliveEnemies();
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
            Destroy(this.gameObject);
            Spawner.DecreaseAliveEnemies();
        }
    
    }

    private IEnumerator WaitToCharge()
    { 
        yield return new WaitForSeconds(chargeTime);
        movementSpeed = MaxMovementSpeed;
    }

    
}

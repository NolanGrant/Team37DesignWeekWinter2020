using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterFire : MonoBehaviour
{
    public float speed;

    private Transform EndPoint;

    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        EndPoint = GameObject.Find("EndPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.up * Time.deltaTime * speed);
        BulletLifeSpan();
    }

    private void BulletLifeSpan() 
    {
        if (EndPoint == null)
        {
            Debug.Log("ENDPOINT NOT SET");
        }
        else if (transform.position.y < EndPoint.position.y)
        {
            MainHealth.hp -= 5;
            Destroy(this.gameObject);
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyCollider"))
        {
            MainHealth.hp -= 5;

            Destroy(this.gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("OnlyInteractEnemies"))
        {
            print("beamhit");
            Destroy(this.gameObject);
        }
    }

    //put damage information here
}

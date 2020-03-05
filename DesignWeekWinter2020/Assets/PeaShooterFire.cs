using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterFire : MonoBehaviour
{
    public float speed;

    private Transform EndPoint;
    // Start is called before the first frame update
    void Start()
    {
        EndPoint = GameObject.Find("EndPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.up * Time.deltaTime * speed);
    }

    private void BulletLifeSpan() 
    {
        if (EndPoint == null)
        {
            Debug.Log("ENDPOINT NOT SET");
        }
        else if (transform.position.y < EndPoint.position.y)
        {
            Destroy(this.gameObject);
        }

    }

    //put damage information here
}

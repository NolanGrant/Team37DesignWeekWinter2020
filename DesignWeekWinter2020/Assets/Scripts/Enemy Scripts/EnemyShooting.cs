using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float fireRate;

    [SerializeField]
    float bulletSpeed;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireBullet", 1f, fireRate);
        transform.parent = null;
    }

    private void Update()
    {
        if(transform.position.y > 6)
        {
            transform.Translate(transform.up * -speed);
        }
        
    }

    private void FireBullet() 
    {
        GameObject shotFired = Instantiate(bullet, transform.position, Quaternion.identity);
        shotFired.GetComponent<PeaShooterFire>().speed = bulletSpeed;
    
    }

    
}

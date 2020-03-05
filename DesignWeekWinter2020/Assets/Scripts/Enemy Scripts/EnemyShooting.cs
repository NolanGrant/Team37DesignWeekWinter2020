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
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireBullet", 1f, fireRate);
    }

    private void FireBullet() 
    {
        GameObject shotFired = Instantiate(bullet, transform.position, Quaternion.identity);
        shotFired.GetComponent<PeaShooterFire>().speed = bulletSpeed;
    
    }

    
}

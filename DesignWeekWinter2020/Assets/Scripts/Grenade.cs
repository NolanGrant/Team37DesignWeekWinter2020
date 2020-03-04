using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float speed;
    public float distance;
    private Vector3 origin;
    private float curScale;
    public float sizeGain;

    private float xDist;
    private float yDist;

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,1,0) * speed);
        xDist = Mathf.Abs(transform.position.x - origin.x);
        yDist = Mathf.Abs(transform.position.y - origin.y);
        curScale = sizeGain * Mathf.Sin(((Mathf.Pow(xDist, 2) + Mathf.Pow(yDist, 2)) / Mathf.Pow(distance, 2)) * Mathf.PI + 0.1f) + 1;
        //Debug.Log(((Mathf.Pow(xDist, 2) + Mathf.Pow(yDist, 2)) / Mathf.Pow(distance, 2)) * Mathf.PI);
        //Debug.Log("Y: " + Mathf.Abs(transform.position.y - origin.y));
        transform.localScale = new Vector3(curScale, curScale, 1);

        if(Mathf.Pow(Mathf.Abs(transform.position.x - origin.x),2) + Mathf.Pow(Mathf.Abs(transform.position.y - origin.y),2) > Mathf.Pow(distance,2))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        //transform.localScale = new Vector3()
    }


}

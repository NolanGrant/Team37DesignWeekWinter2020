using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public GameObject pic1;
    public GameObject pic2;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pic1.transform.Translate(transform.up * -speed);
        pic2.transform.Translate(transform.up * -speed);

        if(pic1.transform.position.y <= -21)
        {
            pic1.transform.position = new Vector3(pic1.transform.position.x, 21, pic1.transform.position.z);
        }
        if (pic2.transform.position.y <= -21)
        {
            pic2.transform.position = new Vector3(pic1.transform.position.x, 21, pic1.transform.position.z);
        }
    }
}

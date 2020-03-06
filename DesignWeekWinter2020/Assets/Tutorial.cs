using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public PlayerController p1;
    public PlayerController p2;

    public GameObject leftarrow;
    public GameObject uparrow;
    public GameObject rightarrow;
    public GameObject downarrow;
    public GameObject controls;

    public GameObject cam;
    public float camspeed;

    public GameObject leftGun;
    public GameObject rightGun;
    public GameObject upGun;
    public GameObject downGun;

    public GameObject leftHit;
    public GameObject rightHit;
    public GameObject leftHit2;
    public GameObject rightHit2;

    public WaveSetUp setup;

    public GameObject skiptext;
    // Start is called before the first frame update
    void Start()
    {
        uparrow.SetActive(false);
        downarrow.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(setup, new Vector3(0, 10, 0), new Quaternion(0, 0, 0, 0));
            Destroy(skiptext);
            Destroy(this.gameObject);
        }

        if(p1.currentGun ==  leftGun && p2.currentGun == rightGun || p1.currentGun == rightGun && p2.currentGun == leftGun)
        {
            Destroy(leftarrow);
            Destroy(rightarrow);
            
            if(cam.transform.position.y < 0)
            {
                cam.transform.Translate(transform.up * camspeed);
            }
            if (cam.GetComponent<Camera>().orthographicSize < 10)
            {
                cam.GetComponent<Camera>().orthographicSize += camspeed;
            }
        }

        if (p1.currentGun == upGun && p2.currentGun == downGun || p1.currentGun == upGun && p2.currentGun == downGun)
        {
            Destroy(uparrow);
            Destroy(downarrow);
            Destroy(controls);
        }


        if (leftHit2 == null && rightHit2 == null)
        {
            Debug.Log("YUP");
            Instantiate(setup, new Vector3(0, 10, 0), new Quaternion(0,0,0,0));
            Destroy(skiptext);
            Destroy(this.gameObject);
        }

        if (leftHit == null && rightHit == null)
        {
            uparrow.SetActive(true);
            downarrow.SetActive(true);
            leftHit2.SetActive(true);
            rightHit2.SetActive(true);
        }


    }
}

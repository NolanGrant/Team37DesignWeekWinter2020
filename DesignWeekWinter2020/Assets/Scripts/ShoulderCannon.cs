using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoulderCannon : MonoBehaviour
{
    private bool shoulderCannonShooting = false;

    public float chargeTime;
    private float currentTime = 0;

    public GameObject laserBeam;
    GameObject currentBeam;

    public float beamLife;
    private float beamTimer;

    public GameObject chargeParticles;

    public bool beamactive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (GetComponent<Guns>().triggerShoot && !shoulderCannonShooting && currentTime == 0)
        {
            GameObject newChargeParticles = Instantiate(chargeParticles, transform.position, Quaternion.identity);
            newChargeParticles.GetComponent<SelfDestruct>().lifespan = chargeTime;

            shoulderCannonShooting = true;
        }

        if (shoulderCannonShooting && currentTime < chargeTime)
        {
            //Debug.Log("charging: " + currentTime);
            currentTime += Time.deltaTime;
        }
        else if (shoulderCannonShooting && currentTime > chargeTime)
        {
            shoulderCannonShooting = false;
            GameObject instantiatedBeam = GameObject.Instantiate(laserBeam, transform.position, transform.rotation) as GameObject;
            currentBeam = instantiatedBeam;

        }
        */

        if (beamactive == true && currentBeam == null)
        {
            GameObject instantiatedBeam = GameObject.Instantiate(laserBeam, transform.position, transform.rotation) as GameObject;
            currentBeam = instantiatedBeam;
        }

        if (currentBeam != null)
        {
            if (!beamactive)
            {
                currentTime = 0;
                beamTimer = 0;
                DestroyImmediate(currentBeam);
            }
        }

        GetComponent<Guns>().triggerShoot = false;

    }
    
}

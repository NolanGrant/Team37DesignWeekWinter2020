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

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("Ship").transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Guns>().triggerShoot && !shoulderCannonShooting)
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
            currentTime = 0;
            shoulderCannonShooting = false;
            GameObject instantiatedBeam = GameObject.Instantiate(laserBeam, transform.position, transform.rotation) as GameObject;
            currentBeam = instantiatedBeam;

        }

        if (currentBeam != null)
        {
            beamTimer += Time.deltaTime;

            if (beamTimer > beamLife)
            {
                beamTimer = 0;
                DestroyImmediate(currentBeam);
            }
        }

        GetComponent<Guns>().triggerShoot = false;

    }
    
}

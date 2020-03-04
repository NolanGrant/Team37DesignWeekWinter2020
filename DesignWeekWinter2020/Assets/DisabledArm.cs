using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledArm : MonoBehaviour
{
    bool canSpawnNewArm = true;
    public float armSpawnDelay = 3f;
    public GameObject newArmPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnNewArm", armSpawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewArm()
    {
        Instantiate(newArmPrefab, transform.position, Quaternion.identity);
    }
}

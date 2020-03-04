using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmHealth : MonoBehaviour
{

    public float maxHealth = 100;
    public float currentHealth;

    public Slider armHPSlider;

    public GameObject armSegmentExplosionPrefab;
    public GameObject[] armSegments;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        armHPSlider.maxValue = maxHealth;
        armHPSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        armHPSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            foreach(GameObject armSegment in armSegments)
            {
                Instantiate(armSegmentExplosionPrefab, armSegment.transform.position, Quaternion.identity);
                Destroy(armSegment);
            }
        }
    }
}

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
    public float disabledDuration = 3f;
    public Color disabledColor;
    public SpriteRenderer[] disabledEffectedSprites;
    bool destroyed = false;

    Chainsaw myChainsaw;

    public Collider2D[] armColliders;

    private void Awake()
    {
        myChainsaw = GetComponentInChildren<Chainsaw>();
    }

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
        if (currentHealth <= 0 && destroyed == false)
        {
            destroyed = true;
            myChainsaw.enabled = false;
            Invoke("RepairArm", disabledDuration);
            foreach (GameObject armSegment in armSegments)
            {
                Instantiate(armSegmentExplosionPrefab, armSegment.transform.position, Quaternion.identity);
                foreach(SpriteRenderer sprite in disabledEffectedSprites)
                {
                    sprite.color = disabledColor;
                }
            }
        }
    }
    public void RepairArm()
    {
        print("repar");
        destroyed = false;
        myChainsaw.enabled = true;
        currentHealth = maxHealth;
        foreach (SpriteRenderer sprite in disabledEffectedSprites)
        {
            sprite.color = Color.white;
        }
    }
}

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
    public bool destroyed = false;

    Chainsaw myChainsaw;

    public Collider2D[] armColliders;

    CameraShake camShake;

    bool invincibleToInstaKills = false;
    public float armInvincibilityDurationAfterRepair = 0.5f;
    float InvincibilityTimer = 0f;

    private void Awake()
    {
        myChainsaw = GetComponentInChildren<Chainsaw>();
        camShake = Camera.main.GetComponent<CameraShake>();
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

            camShake.LargeImpact();

            foreach (Collider2D col in armColliders)
            {
                col.enabled = false;
            }

            foreach (GameObject armSegment in armSegments)
            {
                Instantiate(armSegmentExplosionPrefab, armSegment.transform.position, Quaternion.identity);
                foreach(SpriteRenderer sprite in disabledEffectedSprites)
                {
                    sprite.color = disabledColor;
                }
            }
            
            Invoke("RepairArm", disabledDuration);
        }
    }

    public void TakeLethalDamage()
    {
        if(invincibleToInstaKills == false)
        {
            currentHealth = 0;
        }
        else
        {

        }
    }

    private void FixedUpdate()
    {
        if(invincibleToInstaKills == true)
        {
            InvincibilityTimer += Time.fixedDeltaTime;
            if(InvincibilityTimer >= armInvincibilityDurationAfterRepair)
            {
                invincibleToInstaKills = false;
            }
        }
    }

    public void RepairArm()
    {
        destroyed = false;
        myChainsaw.enabled = true;
        currentHealth = maxHealth;
        foreach (SpriteRenderer sprite in disabledEffectedSprites)
        {
            sprite.color = Color.white;
        }
        foreach (Collider2D col in armColliders)
        {
            col.enabled = true;
        }
        invincibleToInstaKills = true;
        InvincibilityTimer = 0;
    }
}

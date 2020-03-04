using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float healthVal;
    public float healthMax;
    public Image healthBarImg;

    // Update is called once per frame
    void Update()
    {
        healthBarImg.fillAmount = healthVal / healthMax;
    }
}

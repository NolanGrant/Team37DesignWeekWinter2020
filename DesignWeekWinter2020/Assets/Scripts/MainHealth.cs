using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainHealth : MonoBehaviour
{
    public static float hp = 100;

    public Slider barFill;
    // Start is called before the first frame update
    void Start()
    {
        barFill.maxValue = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        barFill.value = hp;

        if(hp <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}

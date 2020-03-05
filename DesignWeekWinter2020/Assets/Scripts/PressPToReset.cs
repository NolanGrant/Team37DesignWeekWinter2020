using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressPToReset : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p"))
        {
            print("scene reset");
            SceneManager.LoadScene(1);
        }       
    }
}

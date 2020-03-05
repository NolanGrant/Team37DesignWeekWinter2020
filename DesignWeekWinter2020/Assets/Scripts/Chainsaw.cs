using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string chainSawClashEvent = "";
    FMOD.Studio.EventInstance chainSawClash;

    public GameObject sparksPrefab;

    public float damagePerSecondToTeammate = 100;

    // Start is called before the first frame update
    void Start()
    {
        chainSawClash = FMODUnity.RuntimeManager.CreateInstance(chainSawClashEvent);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("LeftArm") || collision.collider.gameObject.layer == LayerMask.NameToLayer("RightArm"))
        {
            Instantiate(sparksPrefab, collision.GetContact(0).point, Quaternion.identity);

            chainSawClash.start();

            collision.gameObject.GetComponentInParent<ArmHealth>().currentHealth -= damagePerSecondToTeammate * Time.fixedDeltaTime;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("LeftArm") || collision.collider.gameObject.layer == LayerMask.NameToLayer("RightArm"))
        {
            Instantiate(sparksPrefab, collision.GetContact(0).point, Quaternion.identity);

            collision.gameObject.GetComponentInParent<ArmHealth>().currentHealth -= damagePerSecondToTeammate * Time.fixedDeltaTime;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("LeftArm") || collision.collider.gameObject.layer == LayerMask.NameToLayer("RightArm"))
        {
            chainSawClash.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}

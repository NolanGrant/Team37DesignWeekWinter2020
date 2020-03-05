using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;
	
	// How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

    public float largeImpactDuration = 0.1f;
    public float largeShakeAmount = 0.3f;
    public float smallImpactDuration = 0.1f;
    public float smallShakeAmount = 0.3f;
	
	Vector3 originalPos;
	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
            var random = new Vector2(Mathf.PerlinNoise(Time.time * 30f, 0), Mathf.PerlinNoise(0f, Time.time * 30f));
			camTransform.localPosition = originalPos + (Vector3)random * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}

    public void SmallImpact()
    {
        shakeDuration = smallImpactDuration;
        shakeAmount = smallShakeAmount;
    }

    public void LargeImpact()
    {
        shakeDuration = largeImpactDuration;
        shakeAmount = largeShakeAmount;     
    }
}

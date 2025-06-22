using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private Light flickerLight;              
    public float minIntensity= 0.5f;         // Minimum light intensity
    public float maxIntensity= 1.5f;         // Maximum light intensity
    public float flickerSpeed= 0.1f;         // Time interval between intensity changes

    void Start()
    {
        // Get the Light component attached to this GameObject
        flickerLight=GetComponent<Light>();

        //Repeatedly call Flicker() at intervals of flickerSpeed seconds
        InvokeRepeating("Flicker", 0f, flickerSpeed);
    }

    // Randomly change the light intensity to simulate flickering
    void Flicker()
    {
        if (flickerLight!= null)
        {
            flickerLight.intensity=Random.Range(minIntensity, maxIntensity);
        }
    }
}

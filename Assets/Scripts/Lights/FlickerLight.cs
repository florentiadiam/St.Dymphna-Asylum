using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private Light flickerLight;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    public float flickerSpeed = 0.1f;

    void Start()
    {
        flickerLight = GetComponent<Light>();
        InvokeRepeating("Flicker", 0f, flickerSpeed);
    }

    void Flicker()
    {
        if (flickerLight != null)
        {
            flickerLight.intensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}

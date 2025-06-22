using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    private Light flashlight;

    void Start()
    {
        flashlight= GetComponent<Light>();
        flashlight.enabled=false; 
    }

    void Update()
    {
        //if key F is pressed then enable the flashlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled=!flashlight.enabled;
        }
    }
}

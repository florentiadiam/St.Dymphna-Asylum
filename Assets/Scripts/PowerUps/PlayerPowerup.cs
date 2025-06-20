using System.Collections;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    // Power-up state flags
    private bool hasSpeed, hasInvisibility, hasCameraSwitch, hasFlashlight;

    [Header("UI Elements")]
    public GameObject invisibilityImage;    
    public GameObject speedImage;           
    public GameObject flashlightPrompt;     

    [Header("Power-Up Durations (seconds)")]
    public float speedDuration = 15f;
    public float invisibilityDuration = 15f;
    public float cameraSwitchDuration = 7f;

    [Header("Flashlight")]
    public GameObject flashlightObject;     
    public GameObject playerModel;          
    private PlayerMovement movement;        
    private float normalSpeed;              
    public float boostedSpeed = 17f;        

    public Camera thirdPersonCam;
    public Camera topDownCam;

    public bool isInvisible { get; private set; } = false;

    void Start()
    {
        // Cache player movement and default speed
        movement = GetComponent<PlayerMovement>();
        normalSpeed = movement.moveSpeed;

        // Set default camera state
        thirdPersonCam.enabled = true;
        topDownCam.enabled = false;

        // Hide flashlight and UI prompts at start
        if (flashlightObject != null)
            flashlightObject.SetActive(false);

        if (flashlightPrompt != null)
            flashlightPrompt.SetActive(false);

        // Hide speed and invisibility images at start
        if (invisibilityImage != null)
            invisibilityImage.SetActive(false);

        if (speedImage != null)
            speedImage.SetActive(false);
    }

    // Called when the player collects a power-up
    public void AddPowerUp(PowerUpType type)
    {
        switch (type)
        {
            case PowerUpType.Speed:
                hasSpeed = true;
                break;
            case PowerUpType.Invisibility:
                hasInvisibility = true;
                break;
            case PowerUpType.CameraSwitch:
                hasCameraSwitch = true;
                break;
            case PowerUpType.Flashlight:
                hasFlashlight = true;

                if (flashlightPrompt != null)
                    flashlightPrompt.SetActive(true);
                    Debug.Log("Flashlight Prompt ACTIVATED");

                break;
        }
    }

    void Update()
    {
        // Activate Speed Power-Up
        if (Input.GetKeyDown(KeyCode.Alpha1) && hasSpeed)
            StartCoroutine(ApplySpeedBoost());

        // Activate Invisibility Power-Up
        if (Input.GetKeyDown(KeyCode.Alpha2) && hasInvisibility)
            StartCoroutine(ApplyInvisibility());

        // Activate Camera Switch Power-Up
        if (Input.GetKeyDown(KeyCode.Alpha3) && hasCameraSwitch)
            StartCoroutine(ApplyCameraSwitch());

        // Toggle flashlight if collected
        if (hasFlashlight && Input.GetKeyDown(KeyCode.F))
        {
            if (flashlightObject != null)
            {
                flashlightObject.SetActive(!flashlightObject.activeSelf);

                Light light = flashlightObject.GetComponentInChildren<Light>();
                if (light != null)
                    light.enabled = flashlightObject.activeSelf;

                if (flashlightPrompt != null)
                    flashlightPrompt.SetActive(false); // Hide prompt on use

                Debug.Log("Flashlight toggled. Active: " + flashlightObject.activeSelf);
            }
        }

    }

    // Speed Boost
    IEnumerator ApplySpeedBoost()
    {
        hasSpeed = false;
        movement.moveSpeed = boostedSpeed;

        if (speedImage != null)
            speedImage.SetActive(true); // Show speed scroll image

        yield return new WaitForSeconds(speedDuration);

        movement.moveSpeed = normalSpeed;

        if (speedImage != null)
            speedImage.SetActive(false); // Hide scroll image
    }

    // Invisibility 
    IEnumerator ApplyInvisibility()
    {
        hasInvisibility = false;
        isInvisible = true;

        if (invisibilityImage != null)
            invisibilityImage.SetActive(true); // Show invisibility scroll

        // Hide player model
        foreach (Renderer r in playerModel.GetComponentsInChildren<Renderer>())
            r.enabled = false;

        yield return new WaitForSeconds(invisibilityDuration);

        // Show player model again
        foreach (Renderer r in playerModel.GetComponentsInChildren<Renderer>())
            r.enabled = true;

        if (invisibilityImage != null)
            invisibilityImage.SetActive(false); // Hide scroll

        isInvisible = false;
    }

    // Temporary camera switch 
    IEnumerator ApplyCameraSwitch()
    {
        hasCameraSwitch = false;

        thirdPersonCam.enabled = false;
        topDownCam.enabled = true;

        yield return new WaitForSeconds(cameraSwitchDuration);

        topDownCam.enabled = false;
        thirdPersonCam.enabled = true;
    }
}

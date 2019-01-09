using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float controlXSpeed = 30f;
    [Tooltip("In ms^-1")] [SerializeField] float controlYSpeed = 20f;
    [Tooltip("In meter")] [SerializeField] float xRange = 25f;
    [Tooltip("In meter")] [SerializeField] float yRange = 10f;

    [Header("Weapons")]
    [SerializeField] GameObject[] guns;

    [Header("Screen-Position Factor")]
    [SerializeField] float posPitchFactor = -1.5f;
    [SerializeField] float posYawFactor = 1.8f;

    [Header("Control-Throw Factor")]
    [SerializeField] float controlPitchFactor = -20f;   
    [SerializeField] float controlRollFactor = -30f;

    float xThrow, yThrow;
    bool isControlEnabled = true;

	// Update is called once per frame
	void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * posPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToControlThrow + pitchDueToPosition;

        float yaw = transform.localPosition.x * posYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlXSpeed * Time.deltaTime;
        float yOffset = yThrow * controlYSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    public void PlayerDeath()         //called by string ref
    {
        isControlEnabled = false;
    }

    private void ProcessFiring()
    {
            if (CrossPlatformInputManager.GetButton("Fire"))
            {
                ActivateGuns();
            }
            else
            {
                DeactivateGuns();
            }
        
    }

    private void ActivateGuns()
    {
        foreach(GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }
}

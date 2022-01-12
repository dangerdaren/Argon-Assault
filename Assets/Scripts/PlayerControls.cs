using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float xInput, yInput;

    [Header("MOVEMENT")]

        [Tooltip("How fast the ship moves up and down based on player input.")]
        [SerializeField] private float controlSpeed = 25;
        
        [Tooltip("The horizontal bounds of the ship's movement from center.")]
        [SerializeField] private float xRange = 20f;

        [Tooltip("The vertical bounds of the ship's movement from center.")]
        [SerializeField] private float yRange = 14f;

    public float returnSpeed;
    public int roundsElapsed;

    public bool canMove;


    [Header("ANIMATION")]

        [Tooltip("How much the ship will pitch based on position on the screen.")]
        [SerializeField] private float positionPitchFactor = -1.5f;
        
        [Tooltip("How much the the ship will pitch based on the player's controller input.")]
        [SerializeField] private float inputPitchFactor = -6f;
        
        [Tooltip("How much the ship will tilt left and right based on position on the screen.")]
        [SerializeField] private float positionYawFactor = 1.73f;
        
        [Tooltip("How much the ship will roll based on player's controller input.")]
        [SerializeField] private float inputRollFactor = -70;


    [Header("WEAPONS")]

        [Tooltip("Add standard lasers here.")]
        [SerializeField] private GameObject[] lasers;

        public bool isFiring = false;
        public float ammoAtFull;
        public float playerAmmo;
        public float ammoLossRate;

    [Header("SFX")]
    [SerializeField] AudioClip laserSFX;


    private AudioSource audioSource;
    bool isCrashing;



    Ammo ammoCount;

    void Start()
    {
        playerAmmo = ammoAtFull;
        ammoCount = FindObjectOfType<Ammo>();
        audioSource = GetComponent<AudioSource>();
        ammoCount.SetStartingAmmo(ammoAtFull);
    }


    void Update()
    {

        ProcessTranslation();
        ProcessRotation();

        ProcessFiring();

        if (!canMove)
        {
            ResetPosition();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            RefillAmmo();
        }
    }


    private void ProcessTranslation()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = -Input.GetAxis("Vertical");

        float xMove = xInput * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xMove;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yMove = yInput * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yMove;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float positionPitch = transform.localPosition.y * positionPitchFactor;
        float inputPitch = yInput * inputPitchFactor;

        float positionYaw = transform.localPosition.x * positionYawFactor;

        float inputRoll = xInput * inputRollFactor;

        float pitch = positionPitch + inputPitch;
        float yaw = positionYaw;
        float roll = inputRoll;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if (playerAmmo > Mathf.Epsilon)
        {
            if (Input.GetButton("Fire1"))
            {
                isFiring = true;
                SetLaserActive(true);

                SubtractAmmo();


                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(laserSFX);
                }

            }
            else
            {
                isFiring = false;
                SetLaserActive(false);
                audioSource.Stop();
            }
        }
        else
        {
            SetLaserActive(false);
        }

    }

    private void SubtractAmmo()
    {
        if (isFiring)
        {
            playerAmmo -= Time.deltaTime*ammoLossRate;
            ammoCount.AdjustAmmo(playerAmmo);
        }
    }

    public void RefillAmmo()
    {
        for (float i = playerAmmo; i < ammoAtFull-.5; i++ )
        {
            playerAmmo++;
            ammoCount.AdjustAmmo(playerAmmo);
        }
    }

    public void SetLaserActive(bool activeStatus)
    {       
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.gameObject.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = activeStatus;
        }
    }

    public void ResetPosition()
    {
        Debug.Log("Moving into position!");
        if (!canMove)
        {
            float step = returnSpeed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, step);
            transform.localEulerAngles = Vector3.zero;

        }
    }


    public void ReEnableFlight()
    {
        canMove = true;
    }
}

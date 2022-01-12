using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float loadLevelDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;

    private GameObject fxParent;
    PlayerControls playerControls;
    Rounds rounds;

    public bool playAgain = false;

    private bool isCrashing = false;
    private bool collisionDisabled = false;

    private void Start()
    {
        playerControls = GetComponent<PlayerControls>();
        rounds = FindObjectOfType<Rounds>();

        fxParent = GameObject.FindWithTag("SpawnAtRuntime");
    }

    private void Update()
    {
        RestartLevel();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCrashing || collisionDisabled) { return; }

        switch (other.gameObject.tag)
        {
            case "LandingZone":
                Debug.Log("Entered Landing Zone");
                playerControls.canMove = false;
                playerControls.RefillAmmo();
                break;
            default:
                BeginCrashSequence();
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "LandingZone")
        {
            playerControls.ReEnableFlight();
            rounds.UpdateCount();
        }
    }

    private void BeginCrashSequence()
    {
        isCrashing = true;

        Instantiate(crashVFX, transform.position, Quaternion.identity, fxParent.transform);

        GetComponent<PlayerControls>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerControls>().SetLaserActive(false);

        Invoke("ReloadLevel", loadLevelDelay);
    }

    private void ReloadLevel()
    {
        playAgain = false;
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

    public void RestartLevel()
    {
        if (Input.GetKeyDown(KeyCode.Y) && playAgain)
        {
            ReloadLevel();
        }
    }

}

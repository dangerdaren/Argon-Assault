using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] ParticleSystem beenHitFX;
    [SerializeField] GameObject splodeFX;
    AudioSource hitSFX;

    [SerializeField] int hitPoints = 2;
    [SerializeField] int destroyValue = 5;

    ScoreBoard scoreBoard;
    EnemiesLeft enemiesLeft;
    GameObject fxParent;

    private bool isDying = false;


    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        enemiesLeft = FindObjectOfType<EnemiesLeft>();

        fxParent = GameObject.FindWithTag("SpawnAtRuntime");

        AddRigidBody();

        hitSFX = GetComponent<AudioSource>();

    }

    private void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints --;

        beenHitFX.Play();
        hitSFX.PlayOneShot(hitSFX.clip);


        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        if (isDying) { return; }
        else
        {
            isDying = true;
            scoreBoard.IncreaseScore(destroyValue);
            GameObject deathFX = Instantiate(splodeFX, transform.position, Quaternion.identity, fxParent.transform); // if VFX is in Assets

            enemiesLeft.SubtractEnemy();

            Destroy(gameObject);
        }

    }
   
}

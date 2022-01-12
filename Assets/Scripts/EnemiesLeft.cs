using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesLeft : MonoBehaviour
{
    GameObject player;
    BoxCollider playerCollider;

    CollisionHandler collisionHandler;

    PlayerControls playerControls;
    GameOver gameOver;
    TMP_Text enemiesLeftText;
    TMP_Text gameOverText;


    public int totalEnemies = 10;
    public int enemiesLeft;
    public bool noEnemies = false;

    // Start is called before the first frame update
    void Start()
    {

        collisionHandler = FindObjectOfType<CollisionHandler>();

        player = GameObject.FindWithTag("Player");
        playerCollider = player.GetComponent<BoxCollider>();

        playerControls = FindObjectOfType<PlayerControls>();

        gameOver = FindObjectOfType<GameOver>();
        gameOverText = gameOver.GetComponent<TMP_Text>();

        enemiesLeftText = GetComponent<TMP_Text>();

        enemiesLeft = totalEnemies;
        UpdateEnemyCount();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubtractEnemy()
    {
        enemiesLeft--;
        UpdateEnemyCount();
        if (enemiesLeft == 0)
        {
            gameOverText.text = ($"press y to \nplay again");
            playerControls.canMove = false;
            playerCollider.enabled = false;
            Debug.Log($"canMove = {playerControls.canMove}");
            Debug.Log($"collider = {playerCollider.enabled}");
            collisionHandler.playAgain = true;

        }
    }

    public void UpdateEnemyCount()
    {
        enemiesLeftText.text = ($"Enemies Left \n{enemiesLeft}/{totalEnemies}");
    }


}

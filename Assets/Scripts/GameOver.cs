using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    GameObject gameOver;
    PlayerControls playerControls;

    private void Start()
    {
        gameOver = gameObject;
        playerControls = FindObjectOfType<PlayerControls>();
    }
    public void EndGame()
    {
        gameOver.SetActive(true);
    }

}

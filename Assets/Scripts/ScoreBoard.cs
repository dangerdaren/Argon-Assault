using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    // todo factor all considerations into scoring system.

    int score;
    TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = ("\n Score");
    }

    public void IncreaseScore(int amountToAdd)
    {
        score += amountToAdd;
        UpdateScore(score);
    }

    public void DecreaseScore (int amountToSubtract)
    {
        score -= amountToSubtract;
        UpdateScore(score);
    }

    public void UpdateScore(int newAmount)
    {
        scoreText.text = ($"Score \n{score.ToString()}");
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rounds : MonoBehaviour
{
    ScoreBoard score;
    TMP_Text roundsPlayedText;
    public int roundsPlayed;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreBoard>();
        roundsPlayedText = GetComponent<TMP_Text>();
        roundsPlayedText.text = ("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCount()
    {
        roundsPlayed++;
        roundsPlayedText.text = ($"Attempt \n{roundsPlayed}");

        if (roundsPlayed > 1)
        {
            score.DecreaseScore(10);
        }

        
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private static float score;  // everyone has the same score
    private static Text scoreText; // everyone has the same text

    // Use this for initialization
    internal void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateText();

    }

    public static void AddToScore(float points)
    {
        score += points;
        UpdateText();
    }

    private static void UpdateText()
    {
        scoreText.text = String.Format("Score: {0}", score);
    }

    void Update()
    {
        if (score == 20) // Make smaller to decrease difficulty
        {
            EndingStatement.Statement.Won();
        }
    }
}
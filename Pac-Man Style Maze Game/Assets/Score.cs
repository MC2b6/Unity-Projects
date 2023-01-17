using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    /// <summary>
    /// Field to store single score object
    /// </summary>
    private static float MyScore;

    /// <summary>
    /// Field to store the text component
    /// </summary>
    private static Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
        UpdateText();
    }

    public static void AddToScore(float amount)
    {
        MyScore += amount;
        UpdateText();
    }

    public static float GetScore()
    {
        return MyScore;
    }

    public static void ResetScore()
    {
        MyScore = 0;
    }

    private static void UpdateText()
    {
        ScoreText.text = String.Format("Score: {0}", MyScore);
    }
}

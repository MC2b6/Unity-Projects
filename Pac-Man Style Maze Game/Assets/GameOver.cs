using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    /// <summary>
    /// Field to hold single object;
    /// </summary>
    public static GameOver End;

    /// <summary>
    /// Fields to store the text components
    /// </summary>
    private static Text MyMessage;
    private static Text PointsIndicator;
    private static Text Reset;

    private float EndingScore;

    // Start is called before the first frame update
    void Start()
    {
        End = this;
        var textObjects = GetComponentsInChildren<Text>();

        for (int i = 0; i < textObjects.Length; i++)
        {
            if (textObjects[i].tag == "EndingMessage")
            {
                MyMessage = textObjects[i];
            }
            else if (textObjects[i].tag == "PointsIndicator")
            {
                PointsIndicator = textObjects[i];
            }
            else if (textObjects[i].tag == "Reset")
            {
                Reset = textObjects[i];
            }
        }

        End.gameObject.SetActive(false);
    }

    public void EndGame()
    {
        End.gameObject.SetActive(true);

        MyMessage.text = String.Format("Game Over!");
        PointsIndicator.text = String.Format("Score: {0}", Score.GetScore());
        Reset.text = String.Format("Press Escape to Restart");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && End.gameObject == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Score.ResetScore();
            Lives.AddLife();
        }
    }
}

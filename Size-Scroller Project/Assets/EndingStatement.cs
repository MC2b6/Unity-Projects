using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingStatement : MonoBehaviour
{
    /// <summary>
    /// Single EndingStatement object
    /// </summary>
    public static EndingStatement Statement;

    public static Text StatementText;

    void Start()
    {
        Statement = this;
        StatementText = GetComponent<Text>();
        Statement.gameObject.SetActive(false);
    }

    public void Lost()
    {
        try
        {
            Statement.gameObject.SetActive(true);
            StatementText.text = "You lose";
            Time.timeScale = 0;
        } catch (MissingReferenceException)
        {
        }
    }

    public void Won()
    {
        Statement.gameObject.SetActive(true);
        StatementText.text = "You win!";
        Time.timeScale = 0;
    }
}
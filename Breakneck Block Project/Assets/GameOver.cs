using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    /// <summary>
    /// GameOver singleton
    /// </summary>
    private static GameOver MyGameOver;

    // Start is called before the first frame update
    void Start()
    {
        MyGameOver = this;
        MyGameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Makes the game object active
    public static void ActivateGameOver()
    {
        MyGameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    /// <summary>
    /// Field to store single lives object
    /// </summary>
    public static float MyLives;

    /// <summary>
    /// Field to store the text component
    /// </summary>
    private static Text LivesText;

    // Start is called before the first frame update
    void Start()
    {
        LivesText = GetComponent<Text>();
        MyLives = 3;
        UpdateText();
    }

    public static void SubtractFromLives()
    {
        MyLives -= 1;
        UpdateText();
    }

    public static float GetLives()
    {
        return MyLives;
    }

    public static void AddLife()
    {
        MyLives += 1;
    }

    private static void UpdateText()
    {
        LivesText.text = String.Format("Lives: {0}", MyLives);
    }
}

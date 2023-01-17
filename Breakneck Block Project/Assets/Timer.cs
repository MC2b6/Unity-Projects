using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    /// <summary>
    /// Time to be printed
    /// </summary>
    private static float MyTime = 0;

    /// <summary>
    /// Text component
    /// </summary>
    private static Text TimeText;

    /// <summary>
    /// Timer for next time increase
    /// </summary>
    private static float IncreaseTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        MyTime = 0;
        TimeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > IncreaseTimer)
        {
            MyTime += 1;
            TimeText.text = String.Format("Time: {0}", MyTime);
            IncreaseTimer += 1;
        }
    }

    // Subtracts 3 seconds from the displayed time
    public static void SubtractThree()
    {
        MyTime -= 3;
        TimeText.text = String.Format("Time: {0}", MyTime);
    }

    // Returns MyTime so it can be printed at GameOver
    public static float GetMyTime()
    {
        return MyTime;
    }
}

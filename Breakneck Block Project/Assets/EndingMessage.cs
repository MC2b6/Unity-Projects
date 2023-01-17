using System;
using UnityEngine;
using UnityEngine.UI;

public class EndingMessage : MonoBehaviour
{
    /// <summary>
    /// Text component
    /// </summary>
    private static Text EndingText;

    // Start is called before the first frame update
    void Start()
    {
        EndingText = GetComponent<Text>();
    }

    // Message for when the end of the map is reached
    public static void SuccessMessage()
    {
        EndingText.text = String.Format("Success! \n Final Time: {0} \n Press Escape to Try Again", Timer.GetMyTime());
    }

    // Message for when the player falls lower than the lowest block
    public static void FailureMessage()
    {
        EndingText.text = String.Format("Uh-Oh \n Press Escape to Try Again");
    }
}

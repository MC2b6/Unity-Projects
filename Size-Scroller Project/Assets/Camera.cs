using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    /// <summary>
    /// Seconds between camera movements
    /// </summary>
    public float CameraInterval = 0.00001f;

    /// <summary>
    /// Timer for next movement
    /// </summary>
    public float CameraTimer = 1;

    /// <summary>
    /// How much the camera jumps when it updates
    /// </summary>
    public float CameraJump = 0.001f;

    /// <summary>
    /// x-position of camera
    /// </summary>
    public float x = 0;

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale == 0)
        {
            return;
        }
        else if (Time.time > CameraTimer)
        {
            x += CameraJump;
            transform.localPosition = new Vector3(x, 0, -10);
            transform.position = transform.TransformVector(transform.localPosition);
            CameraTimer += CameraInterval;
        }
    }
}

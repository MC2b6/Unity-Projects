using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    /// <summary>
    /// Field to store the player game object
    /// </summary>
    public GameObject MyPlayer;

    /// <summary>
    /// Distance between camera and player
    /// </summary>
    private Vector3 CameraDistance;

    // Start is called before the first frame update
    void Start()
    {
        CameraDistance = transform.position - MyPlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = MyPlayer.transform.position + CameraDistance;
    }
}

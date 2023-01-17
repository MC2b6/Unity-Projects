using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Single player object
    /// </summary>
    public static Player MyPlayer;

    /// <summary>
    ///  Field to store the player's rigid body
    /// </summary>
    public Rigidbody2D RigidBody;

    /// <summary>
    ///  Player's movement speed
    /// </summary>
    public float Speed = 10;

    /// <summary>
    ///  Static field to hold default localScale of the player transform
    /// </summary>
    static private Vector3 DefaultScale;

    /// <summary>
    /// Sound for collecting a coin
    /// </summary>
    public AudioClip CoinSound;

    /// <summary>
    /// Sound for losing a point
    /// </summary>
    public AudioClip SubtractSound;

    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = this;
        RigidBody = GetComponent< Rigidbody2D >();
        DefaultScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = Input.GetAxis("Horizontal");
        RigidBody.velocity = new Vector2(direction * Speed, RigidBody.velocity.y);

        if (Input.GetKey(KeyCode.UpArrow) &&
            transform.localScale == DefaultScale &&
            transform.localPosition.y <= 5)
        {
            RigidBody.velocity = new Vector2(direction * Speed, Speed);
        }

        var x = DefaultScale.x / 2;
        var y = DefaultScale.y / 2;
        if (Input.GetKeyDown(KeyCode.DownArrow) &&
            Time.timeScale != 0)
        {
            transform.localScale = new Vector3(x, y, DefaultScale.z);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.localScale = DefaultScale;
        }
    }

    public void PlayCoinSound()
    {
        GetComponent<AudioSource>().PlayOneShot(CoinSound, 1.0f);
    }

    public void PlaySubtractSound()
    {
        GetComponent<AudioSource>().PlayOneShot(SubtractSound, 1.0f);
    }

    void OnBecameInvisible()
    {
        EndingStatement.Statement.Lost();
    }
}

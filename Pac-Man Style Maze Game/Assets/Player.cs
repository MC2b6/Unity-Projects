using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    /// <summary>
    ///  Field to store the player's rigid body
    /// </summary>
    private Rigidbody2D RigidBody;

    /// <summary>
    ///  Player's movement speed
    /// </summary>
    private float Speed = 4;

    /// <summary>
    ///  Field to hold position of the player transform
    /// </summary>
    private static Vector3 Pos;

    /// <summary>
    /// Sound for collecting a pellet
    /// </summary>
    public AudioClip PelletSound;

    /// <summary>
    /// Sound for collecting a power-pellet
    /// </summary>
    public AudioClip PowerPelletSound;

    /// <summary>
    /// Sound for colliding with a ghost normally
    /// </summary>
    public AudioClip LoseLifeSound;

    /// <summary>
    /// Sound for colliding with a ghost in chase mode
    /// </summary>
    public AudioClip Plus20Sound;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal_direction = Input.GetAxis("Horizontal");
        var vertical_direction = Input.GetAxis("Vertical");
        RigidBody.velocity = new Vector2(horizontal_direction * Speed, vertical_direction * Speed);

        if (transform.position.x < -7.8)
        {
            Pos.x = 8.2f;
            transform.position = new Vector3(Pos.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 8.4)
        {
            Pos.x = -7.6f;
            transform.position = new Vector3(Pos.x, transform.position.y, transform.position.z);
        }

        if (FindObjectOfType<Pellet>() == null &&
            FindObjectOfType<PowerPellet>() == null &&
            Lives.GetLives() > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (FindObjectOfType<Pellet>() == null &&
                FindObjectOfType<PowerPellet>() == null &&
                Lives.GetLives() == 0)
        {
            GameOver.End.EndGame();
        }
        else if (Lives.GetLives() < 0)
        {
            GameOver.End.EndGame();
        }
    }

    IEnumerator PowerPelletPickup()
    {
        Speed = 8;
        yield return new WaitForSeconds(7);
        Speed = 4;
    }

    public float GetSpeed()
    {
        return Speed;
    }

    public void SetToStartingPos()
    {
        transform.position = new Vector3(0.23f, -3.72f, 0);
    }

    public void PlayPelletSound()
    {
        GetComponent<AudioSource>().PlayOneShot(PelletSound, 1.0f);
    }

    public void PlayPowerPelletSound()
    {
        GetComponent<AudioSource>().PlayOneShot(PowerPelletSound, 1.0f);
    }

    public void PlayLoseLifeSound()
    {
        GetComponent<AudioSource>().PlayOneShot(LoseLifeSound, 1.0f);
    }

    public void PlayPlus20Sound()
    {
        GetComponent<AudioSource>().PlayOneShot(Plus20Sound, 1.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObject = collision.collider.gameObject;

        if (collisionObject.tag == "Point" || collisionObject.tag == "GhostBlocker")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<CircleCollider2D>());
        }

        else if (collisionObject.GetComponent<Pellet>() != null)
        {
            PlayPelletSound();
        }

        else if (collisionObject.tag == "PowerPellet")
        {
            PlayPowerPelletSound();
            StartCoroutine(PowerPelletPickup());
        }
    }
}

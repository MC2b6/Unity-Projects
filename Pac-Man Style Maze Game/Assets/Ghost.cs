using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class Ghost : MonoBehaviour
{
    /// <summary>
    ///  Field to store the ghost's rigid body
    /// </summary>
    private Rigidbody2D RigidBody;

    ///// <summary>
    /////  Direction the ghost is facing
    ///// </summary>
    private Vector3 FacingDirection;

    ///// <summary>
    /////  Original ghost color
    ///// </summary>
    private Color OriginalColor;

    /// <summary>
    ///  Field to store ghost prefab
    /// </summary>
    public GameObject Prefab;

    /// <summary>
    /// Seconds between movements
    /// </summary>
    private float MoveInterval = 0.002f;

    /// <summary>
    /// Timer for next movement
    /// </summary>
    private float MoveTimer = 0;

    /// <summary>
    /// Next point on path
    /// </summary>
    private Vector3 NextPoint;

    /// <summary>
    /// Raycast hit data
    private RaycastHit2D HitData;

    /// <summary>
    /// Path object
    /// </summary>
    public static Path MyPath;

    /// <summary>
    /// Field to store an array of the points
    /// </summary>
    [HideInInspector]
    public Transform[] MyPoints = new Transform[66];

    /// <summary>
    ///  Field to store single player object
    /// </summary>
    public static Player MyPlayer;

    // Start is called before the first frame update
    void Start()
    {
        MoveTimer = Time.time;

        RigidBody = GetComponent<Rigidbody2D>();
        OriginalColor = Color.red;

        MyPath = FindObjectOfType<Path>();
        MyPoints = MyPath.GetComponentsInChildren<Transform>();

        MyPlayer = FindObjectOfType<Player>();

        int random_index = Random.Range(1, 65);
        transform.position = MyPoints[random_index].position;

        SetFacingDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (MyPlayer.GetSpeed() == 8)
        {
            GetComponent<SpriteRenderer>().color = Color.magenta;
        }
        else if (MyPlayer.GetSpeed() == 4)
        {
            GetComponent<SpriteRenderer>().color = OriginalColor;
        }

        if (Time.time > MoveTimer)
        {
            HitData = Physics2D.Raycast(transform.position + FacingDirection * 0.5f, FacingDirection);

            if (HitData.collider != null && HitData.collider.tag != "Point")
            {
                SetPerpendicularFacingDirection();
                HitData = Physics2D.Raycast(transform.position + FacingDirection * 0.5f, FacingDirection);
            }
            if (HitData.collider != null && HitData.collider.tag != "Point")
            {
                FacingDirection *= -1;
                HitData = Physics2D.Raycast(transform.position + FacingDirection * 0.5f, FacingDirection);
            }

            if (HitData.collider != null)
            {
                NextPoint = HitData.point;
                transform.position = lerp(transform.position, NextPoint, 0.01f);

                if (AlmostEqual(transform.position.x, NextPoint.x) &&
                    AlmostEqual(transform.position.y, NextPoint.y))
                {
                    transform.position = HitData.point;
                }
            }

            MoveTimer += MoveInterval;
        }
    }

    void SetFacingDirection()
    {
        int random_number = Random.Range(1, 5);
        if (random_number == 1)
        {
            FacingDirection = Vector3.right;
        }
        else if (random_number == 2)
        {
            FacingDirection = Vector3.left;
        }
        else if (random_number == 3)
        {
            FacingDirection = Vector3.up;
        }
        else if (random_number == 4)
        {
            FacingDirection = Vector3.down;
        }
    }

    void SetPerpendicularFacingDirection()
    {
        int random_number = Random.Range(1, 3);
        if (random_number == 1)
        {
            float temp = FacingDirection.x;
            FacingDirection.x = FacingDirection.y;
            FacingDirection.y = temp;
        }
        else if (random_number == 2)
        {
            float temp = FacingDirection.x;
            FacingDirection.x = FacingDirection.y * -1;
            FacingDirection.y = temp * -1;
        }
    }

    bool AlmostEqual(float a, float b)
    {
        var max_value = Mathf.Max(Mathf.Abs(a), Mathf.Abs(b));
        bool close = Mathf.Abs(a - b) <= 0.06 * max_value;
        return close;
    }

    // linear interpolation between two points
    Vector3 lerp(Vector3 a, Vector3 b, float s)
    {
        float x = a.x + s * (b.x - a.x);
        float y = a.y + s * (b.y - a.y);
        Vector3 lerped = new Vector3(x, y, a.z);
        return lerped;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObject = collision.collider.gameObject;

        if (collisionObject.tag == "Point" || collisionObject.tag == "Ghost")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<CircleCollider2D>());
        }

        else if (collisionObject.tag == "Player" && GetComponent<SpriteRenderer>().color != Color.magenta)
        {
            Lives.SubtractFromLives();
            MyPlayer.SetToStartingPos();
            MyPlayer.PlayLoseLifeSound();
        }

        else if (collisionObject.tag == "Player" && GetComponent<SpriteRenderer>().color == Color.magenta)
        {
            MyPlayer.PlayPlus20Sound();
            Score.AddToScore(20);
            int random_index = Random.Range(1, 65);
            Vector3 new_pos = MyPoints[random_index].position;
            GameObject NewGhost = Instantiate(Prefab.gameObject, new_pos, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

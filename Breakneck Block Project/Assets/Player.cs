using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Player's RigidBody
    /// </summary>
    private Rigidbody RigidBody;

    /// <summary>
    /// Scale for the effect of gravity
    /// </summary>
    private float GravityScale = 10;

    /// <summary>
    /// Scale for the effect of jumping
    /// </summary>
    private float JumpScale = 80;

    /// <summary>
    /// True if can jump, false if can't jump
    /// </summary>
    private bool JumpAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var x_direction = Input.GetAxis("Horizontal") * 40;
        var z_direction = Input.GetAxis("Vertical") * 40;
        RigidBody.velocity = new Vector3(x_direction, RigidBody.velocity.y, z_direction);

        if (JumpAllowed && Input.GetKeyDown(KeyCode.Space))
        {
            JumpAllowed = false;
            Vector2 jumpForce = Vector2.up * JumpScale;
            RigidBody.AddForce(jumpForce, ForceMode.Impulse);
        }

        if (transform.position.y < Map.GetLowestPos().y)
        {
            GameOver.ActivateGameOver();
            EndingMessage.FailureMessage();
        }
    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        RigidBody.AddForce(Physics.gravity * GravityScale);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block" || collision.gameObject.tag == "VanishBlock")
        {
            JumpAllowed = true;
        }

        if (collision.gameObject.tag == "Gem")
        {
            Timer.SubtractThree();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "End")
        {
            GameOver.ActivateGameOver();
            EndingMessage.SuccessMessage();
        }
    }
}

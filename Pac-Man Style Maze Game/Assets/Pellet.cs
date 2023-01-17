using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
      var collisionObject = collision.collider.gameObject;

        if (collisionObject.tag == "Ghost")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<BoxCollider2D>());
        }

        else if (collisionObject.tag == "Player")
        {
            Score.AddToScore(1);
            Destroy(this.gameObject);
        }
    }
}

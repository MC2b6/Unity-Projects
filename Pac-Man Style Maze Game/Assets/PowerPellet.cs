using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObject = collision.collider.gameObject;

        if (collisionObject.tag == "Ghost")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<CircleCollider2D>());
        }

        else if (collisionObject.tag == "Player")
        {
            Destroy(this.gameObject);
            // Chase ghost mode
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOrb : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObject = collision.collider.gameObject;
        var player = GameObject.FindWithTag("Player");

        if (collisionObject != player)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Player.MyPlayer.PlaySubtractSound();
            ScoreKeeper.AddToScore(-1);
            Destroy(this.gameObject);
        }
    }
}

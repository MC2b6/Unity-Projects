using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObject = collision.collider.gameObject;
        var player = GameObject.FindWithTag("Player");

        if (collisionObject == player)
        {
            Player.MyPlayer.PlaySubtractSound();
            ScoreKeeper.AddToScore(-1);
            // Comment out the above line and uncomment the below
            // line to increase difficuly
            // EndingStatement.Statement.Lost();
        }
    }
}

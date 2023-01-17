using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObject = collision.collider.gameObject;
        var player = GameObject.FindWithTag("Player");

        if (collisionObject == player)
        {
            Player.MyPlayer.PlayCoinSound();
            ScoreKeeper.AddToScore(1);
            Destroy(this.gameObject);
        }
    }
}

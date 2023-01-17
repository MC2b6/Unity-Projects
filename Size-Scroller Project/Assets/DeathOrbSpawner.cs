using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOrbSpawner : MonoBehaviour
{
    /// <summary>
    /// Field to store DeathOrb Prefab
    /// </summary>
    public GameObject Prefab;

    /// <summary>
    /// Seconds between spawns (smaller = more difficult)
    /// </summary>
    public float SpawnInterval = 0.2f;

    /// <summary>
    /// Timer for next spawn
    /// </summary>
    public float SpawnTimer = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > SpawnTimer)
        {
            float randomNumber = Random.Range(1,200);
            Vector2 position = new Vector2(randomNumber, 9);
            GameObject DeathOrb = Instantiate(Prefab, position, Quaternion.identity);
            SpawnTimer += SpawnInterval;
        }
    }



}

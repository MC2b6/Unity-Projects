using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishBlock : MonoBehaviour
{
    /// <summary>
    /// Seconds between vanishing
    /// </summary>
    private float VanishInterval = 2;

    /// <summary>
    /// Timer for next vanish
    /// </summary>
    private float VanishTimer = 1;

    IEnumerator BlockVanish()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > VanishTimer)
        {
            StartCoroutine(BlockVanish());
            VanishTimer += VanishInterval;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Map : MonoBehaviour
{
    /// <summary>
    /// Position where highest map generation starts 
    /// </summary>
    static private Vector3 CurrPosOne = new Vector3(0, -10, 30);

    /// <summary>
    /// Position where second highest map generation starts 
    /// </summary>
    static private Vector3 CurrPosTwo = new Vector3(-30, -210, 30);

    /// <summary>
    /// Position where third highest map generation starts 
    /// </summary>
    static private Vector3 CurrPosThree = new Vector3(-60, -420, 30);

    /// <summary>
    /// Position where fourth highest map generation starts 
    /// </summary>
    static private Vector3 CurrPosFour = new Vector3(-60, -630, 30);

    /// <summary>
    /// Lowest position in the map
    /// </summary>
    static private Vector3 LowestPos = CurrPosFour;

    /// <summary>
    /// Regular block prefab
    /// </summary>
    public GameObject BlockPrefab;

    /// <summary>
    /// Vanishing block prefab
    /// </summary>
    public GameObject VanishPrefab;

    /// <summary>
    /// Ending block prefab
    /// </summary>
    public GameObject EndPrefab;

    /// <summary>
    /// Gem prefab
    /// </summary>
    public GameObject GemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        TrackBuilder(CurrPosOne);
        TrackBuilder(CurrPosTwo);
        TrackBuilder(CurrPosThree);
        TrackBuilder(CurrPosFour);
    }

    // Creates one level of the map
    void TrackBuilder(Vector3 pos)
    {
        Instantiate(BlockPrefab.gameObject, pos, Quaternion.identity, this.transform);
        int random_block_placer;
        int random_block_choice;
        int random_gem_placer;
        for (int i = 0; i < 150; i++)
        {
            random_block_placer = Random.Range(1, 6);
            random_block_choice = Random.Range(1, 5);
            random_gem_placer = Random.Range(1, 8);

            if (random_block_placer == 1)
            {
                pos = new Vector3(pos.x, pos.y, pos.z + 20);
            }
            else if (random_block_placer == 2)
            {
                pos = new Vector3(pos.x + 20, pos.y, pos.z);
            }
            else if (random_block_placer == 3)
            {
                pos = new Vector3(pos.x - 20, pos.y, pos.z);
            }
            else if (random_block_placer == 4)
            {
                pos = new Vector3(pos.x, pos.y + 20, pos.z + 20);
            }
            else if (random_block_placer == 5)
            {
                pos = new Vector3(pos.x, pos.y - 20, pos.z + 20);
            }

            Vector3 gemPos = new Vector3(pos.x, pos.y + 15, pos.z);

            if (!Physics.CheckSphere(pos, 5))
            {
                if (random_block_choice == 1 || random_block_choice == 2 || random_block_choice == 3)
                {
                    Instantiate(BlockPrefab.gameObject, pos, Quaternion.identity, this.transform);
                }
                else if (random_block_choice == 4)
                {
                    Instantiate(VanishPrefab.gameObject, pos, Quaternion.identity, this.transform);
                }

                if (random_gem_placer == 7)
                {
                    Instantiate(GemPrefab.gameObject, gemPos, Quaternion.identity, this.transform);
                }
            }

            if (pos.y < LowestPos.y)
            {
                LowestPos = pos;
            }
        }
        Vector3 endPos = new Vector3(pos.x, pos.y + 20, pos.z + 40);
        Instantiate(EndPrefab.gameObject, endPos, Quaternion.identity, this.transform);
    }

    // Returns LowestPos so it can be compared to the player position
    public static Vector3 GetLowestPos()
    {
        return LowestPos;
    }
}



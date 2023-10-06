using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    public GameObject[] objects;
    public GameObject[] randomizeSpawn;

    public int extraEnemyChance = 15;
    public int spawnTreasureChance = 5;

    // Start is called before the first frame update
    void Start()
    {
        
        
        

        foreach(GameObject spawnpoint in randomizeSpawn)
        {
            int chance = Random.Range(0, 100);

            // Spawn Enemy down middle
            if (spawnpoint == randomizeSpawn[0])
            {
                Instantiate(objects[0], spawnpoint.transform.position, Quaternion.identity);
            }
            else
            {
                // Spawn Treasure
                if (chance <= spawnTreasureChance)
                {
                    Instantiate(objects[1], spawnpoint.transform.position, Quaternion.identity);
                }

                // Spawn Enemy 
                else if (chance <= extraEnemyChance + spawnTreasureChance)
                {
                    Instantiate(objects[0], spawnpoint.transform.position, Quaternion.identity);
                }

                // Spawn Nothing
                else
                {
                    
                }
            }  
        }
    }
}
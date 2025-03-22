using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Getting objects
    public GameObject[] enemies;
    public GameObject[] powerups;

    //Getting ranges
    private float zEnemySpawnRange = 20.0f;
    private float zPowerupSpawnRange = 22.0f;
    private float xSpawnRangeRight = 2.904f;
    private float xSpawnRangeLeft = -1.71f;
    private float groundLevel = 0;

    //Enemy spawn traits
    private float enemyStartDelay = 0.3f;
    private float enemySpawnTime = 0.45f;

    //Powerup traits
    private float powerupStartDelay = 4.5f;
    private float powerupSpawnTime = 10.0f;


    //Subtracting spawn time
    public float SubtractEnemySpawnTime(float decrease)
    { 
        return enemySpawnTime - decrease;
    }

    //capping spawn time
    public float SetEnemySpawnTime(float cap)
    {
        return enemySpawnTime = cap;
    }



    //Getting player scripts
    private PlayerController playerControllerScript;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Grabbing player object
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        
        //Spawning enemies and powerups randomly
        //Within bounds
        InvokeRepeating("SpawnEnemies", enemyStartDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerups", powerupStartDelay, powerupSpawnTime);

    }

    // Update is called once per frame
    void Update()
    {
      

    }

    void SpawnEnemies()
    {
        //Range where they're spawn
        float randomX = Random.Range(xSpawnRangeLeft, xSpawnRangeRight);

        //Spawning random enemy 
        int randomIndex = Random.Range(0, enemies.Length);

        //Making them spawn near the end of the map
        Vector3 spawnPos = new Vector3(randomX, groundLevel, zEnemySpawnRange);

        //Making sure it spawns only when the game
        //isn't over
        if (playerControllerScript.gameOver == false)
        {
            //Making enemy spawn at the end of the map with random placement
            //in bounds
            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);

        }

          

    }

    void SpawnPowerups()
    {
        //Range where they're spawn
        float randomX = Random.Range(xSpawnRangeLeft, xSpawnRangeRight);

        //Spawning random powerup 
        //int randomIndex = Random.Range(0, enemies.Length);

        //Making them spawn near the end of the map
        Vector3 spawnPos = new Vector3(randomX, groundLevel, zPowerupSpawnRange);

        //Making sure it spawns only when the game
        //isn't over
        if (playerControllerScript.gameOver == false)
        {
            //Making enemy spawn at the end of the map with random placement
            //in bounds
            Instantiate(powerups[0], spawnPos, powerups[0].gameObject.transform.rotation);

        }


    }


}

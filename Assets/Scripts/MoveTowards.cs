using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MoveTowards : MonoBehaviour
{
    private Rigidbody obstacleRb;
    private float zOutOfBounds = -5.0f;


    //Getting player scripts
    private PlayerController playerControllerScript;

    private GameManager movementSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Referencing obstacle
        obstacleRb = GetComponent<Rigidbody>();

        //Grabbing player object
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //Getting game manager script
        movementSpeed = GameObject.Find("Game Manager").GetComponent<GameManager>();



    }

    // Update is called once per frame
    void Update()
    {

        //Calling game over for obstacles
        ObstacleMovement();

        //Destroying objects past a certain point
        DestroyObjects();


    }


    //Destroying objects once they leave the screen
    void DestroyObjects()
    {
        if (transform.position.z < zOutOfBounds)
        {
            Destroy(gameObject);
        }
    }

    void ObstacleMovement()
    {
        //Making sure player boolean is false
        if (playerControllerScript.gameOver == false)
        {

            //Moving obstacle towards screen
            obstacleRb.AddForce(Vector3.back * movementSpeed.GetSpeed());

            //obstacleRb.transform.Translate(Vector3.back * movementSpeed.speed);

        }
        else
        {
            // Stop all obstacles completely w/ physics
            obstacleRb.linearVelocity = Vector3.zero;
            obstacleRb.angularVelocity = Vector3.zero;
        }

    }


}
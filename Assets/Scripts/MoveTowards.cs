using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    private Rigidbody obstacleRb;
    private float zOutOfBounds = -5.0f;
    private float speed = 3.5f;

    //Getting player scripts
    private PlayerController playerControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Referencing obstacle
        obstacleRb = GetComponent<Rigidbody>();

        //Grabbing player object
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();


        
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
        if(transform.position.z < zOutOfBounds )
        {
            Destroy(gameObject);
        }
    }

    void ObstacleMovement()
    {
        //Making sure player boolean is false
        if (playerControllerScript.gameOver == false)
        {
            // Re-enable physics
            //obstacleRb.isKinematic = false;


            //Moving obstacle towards screen
            obstacleRb.AddForce(Vector3.back * speed);

        }
        else
        {
            // Stop all obstacles completely w/ physics
            obstacleRb.linearVelocity = Vector3.zero;
            obstacleRb.angularVelocity = Vector3.zero;

            //Prevent further physics interactions (Throws an error)
            //So I might delete later
            //obstacleRb.isKinematic = false; 
        }

    }

}

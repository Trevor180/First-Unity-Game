using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed;
    private float outOfBoundsLeftX = -2.51f;
    private float outOfBoundsRightX = 2.75f;

    //Signaling that the game is over
    public bool gameOver = false;

    //Grabbing move towards scripts

    private MoveTowards endOfGame;

    //Adding Rigidbody component
    private Rigidbody playerRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Getting component for physics
        playerRb = GetComponent<Rigidbody>();

       

        
    }

    // Update is called once per frame
    void Update()
    {
        //Move character method
        MoveCharacter();

        //Keeping player in bounds
        KeepPlayerInBounds();

    }

    void MoveCharacter()
    {
        //Can move if the game isn't over
        if(gameOver == false)
        {
            //Horizontal input
            horizontalInput = Input.GetAxis("Horizontal");

            //Move side to side with force since we're using physics 
            //NOT TRANSLATE
            playerRb.transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        }

    }

    //Making sure player doesn't go out of bounds
    void KeepPlayerInBounds()
    {
       
        if (transform.position.x > outOfBoundsRightX)
        {
            transform.position = new Vector3(outOfBoundsRightX, transform.position.y, transform.position.z);

        }
        else if (transform.position.x < outOfBoundsLeftX)
        {
            transform.position = new Vector3(outOfBoundsLeftX, transform.position.y, transform.position.z);

        }

    }

    //Collisions with enemies and powerups
    private void OnCollisionEnter(Collision collision)
    {
        //Game over
        if(collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            Debug.Log("Enemy has been hit");

            // Stop all obstacles completely w/ physics
            playerRb.linearVelocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
            //Prevent further physics interactions (Throws an error)
            playerRb.isKinematic = true; 

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Debug.Log("Player has powered up!");

        }
    }
}

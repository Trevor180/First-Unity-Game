using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed;
    private float outOfBoundsLeftX = -2.51f;
    private float outOfBoundsRightX = 2.75f;


    //Sound effects
    private AudioSource playerAudio;
    public AudioClip powerupSound;
    public AudioClip gameOverSound;
    public AudioClip hitEnemySound;
    private float soundEffectVolume = 0.06f;



    //Signaling that the game is over
    public bool gameOver = false;

    //If player has bomb power up
    public bool hasBomb = false;


    //Grabbing move towards scripts

    private MoveTowards endOfGame;

    //Adding Rigidbody component
    private Rigidbody playerRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Getting component for physics
        playerRb = GetComponent<Rigidbody>();

        //Referencing Audio Source
        playerAudio = GetComponent<AudioSource>();
       

        
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

        //Bomb powerup and hits enemy
        if (collision.gameObject.CompareTag("Enemy") && hasBomb == true)
        {

            //Destroying enemy
            Destroy(collision.gameObject);

            //Player destroys obstacle sound
            playerAudio.PlayOneShot(hitEnemySound, soundEffectVolume);

            //Turning powerup bomb off
            hasBomb = false;

            Debug.Log("Enemy has blown up");

            //Stopping next block of code from running
            return;

        }

        //Game over (when player doesn't have a bomb
        if (collision.gameObject.CompareTag("Enemy") && hasBomb == false)
        {
            gameOver = true;
            Debug.Log("Enemy has been hit");

            StopPlayer();

            //Player game over audio
            playerAudio.PlayOneShot(hitEnemySound, soundEffectVolume);
            playerAudio.PlayOneShot(gameOverSound, 0.05f);
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        //Passing other parameter into functions
        PlayerHasBomb(other);
        PlayerBonusPoints(other);
    }



    void StopPlayer()
    {
        // Stop all obstacles completely w/ physics
        playerRb.linearVelocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
        //Prevent further physics interactions (Throws an error)
        playerRb.isKinematic = true;

    }

    //When player picks up bomb powerup
    void PlayerHasBomb(Collider other)
    {
         if (other.gameObject.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);
            Debug.Log("Player has a bomb!");
            hasBomb = true;
            playerAudio.PlayOneShot(powerupSound, soundEffectVolume);

        }

    }

    //When player picks up bonus power up
    void PlayerBonusPoints(Collider other)
    {
        if (other.gameObject.CompareTag("Bonus Points"))
        {
            Destroy(other.gameObject);
            Debug.Log("Player got bonus points!");
            playerAudio.PlayOneShot(powerupSound, soundEffectVolume);

        }

    }
}

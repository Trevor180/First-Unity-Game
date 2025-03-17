using UnityEngine;

public class RepeatMountains : MonoBehaviour
{
    //Getting start position
    private Vector3 startPos;

    //Repeat width
    private float repeatWidth;


    //Getting player scripts
    private PlayerController playerControllerScript;

    private float mountainSpeed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Grabbing player object
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //Getting half the size of each mountain to repeat
        repeatWidth = GetComponent<BoxCollider>().size.z;


        //Getting mountains current position
        startPos = transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        //Moving mountains when game has started
        if(playerControllerScript.gameOver == false)
        {
            MoveMountains();
        }
        
      
        
    }

    void MoveMountains()
    {
        //Moving mountains backwards
        transform.Translate(Vector3.back * mountainSpeed * Time.deltaTime);

        if (transform.position.z < startPos.z - repeatWidth )
        {
            Destroy(gameObject);

            Instantiate(gameObject, startPos, transform.rotation);
            //transform.position = startPos;
        }


    }
}

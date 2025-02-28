using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed;
    private float outOfBoundsLeftX = -2.51f;
    private float outOfBoundsRightX = 2.75f;

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

        //Horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        //Move side to side with force since we're using physics 
        //NOT TRANSLATE
        playerRb.transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

    }

    void KeepPlayerInBounds()
    {
        //Making sure player doesn't go out of bounds
        if (transform.position.x > outOfBoundsRightX)
        {
            transform.position = new Vector3(outOfBoundsRightX, transform.position.y, transform.position.z);

        }
        else if (transform.position.x < outOfBoundsLeftX)
        {
            transform.position = new Vector3(outOfBoundsLeftX, transform.position.y, transform.position.z);

        }

    }
}

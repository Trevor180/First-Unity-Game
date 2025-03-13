using UnityEngine;

public class Explode : MonoBehaviour
{
    //Explosion effect
    public GameObject explosionPrefab;

    //Getting player scripts
    private PlayerController playerControllerScript;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Grabbing player object
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerControllerScript.hasBomb == true)
        {

            //Play explosion
            explosionPrefab.SetActive(true);


        }


    }

}

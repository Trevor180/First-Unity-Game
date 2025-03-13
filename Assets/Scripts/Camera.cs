using UnityEngine;

public class Camera : MonoBehaviour
{

    private AudioSource gameplaySound;
    private PlayerController playerControllerScript;
    internal CameraClearFlags clearFlags;

    public static Camera main { get; internal set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Referencing player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //Referencing gameplay music
        gameplaySound = GetComponent<AudioSource>();

        

        
    }

    // Update is called once per frame
    void Update()
    {
        PlayMusic();

    }


    //Playing music when game is going
    void PlayMusic()
    {
        if(playerControllerScript.gameOver == false)
        {
            //PLaying sound
            gameplaySound.enabled = true;


        }
        else
        {
            //Stopping sound
            gameplaySound.enabled = false;

        }
    }
}

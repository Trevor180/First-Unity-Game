using UnityEngine;

public class Camera : MonoBehaviour
{

    //Getting gameplay music privately
    private AudioSource gameplaySound;

    //Getting title music publically

    public AudioSource titleMusic;
    private PlayerController playerControllerScript;
    internal CameraClearFlags clearFlags;

    public static Camera main { get; internal set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Referencing Gameplay Sound
        gameplaySound = GetComponent<AudioSource>();

        //Referencing player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        GameplayPlayMusic();

    }


    //Playing music when game is going
    void GameplayPlayMusic()
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

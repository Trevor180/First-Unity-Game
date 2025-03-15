using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button button;


    //Getting player scripts
    private PlayerController playerControllerScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Grabbing player object
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();



        //Referencing button
        button = GetComponent<Button>();

        //Setting up method for when button is clicked
        button.onClick.AddListener(SetDifficulty);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Starting game when button is clicked
    void SetDifficulty()
    {
        playerControllerScript.StartGame();


    }
}

using UnityEngine;
using UnityEngine.SceneManagement; //Managing Scene
using UnityEngine.UI; //Grabbing buttons

public class GameManager : MonoBehaviour
{

    //Making button variable
    public Button restartButton;

    //Getting player scripts
    private PlayerController playerControllerScript;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Grabbing player object
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //Not showing  restart button
        //restartButton.gameObject.SetActive(false);

        //Restarting game when restart button is clicked
        restartButton.onClick.AddListener(RestartGame);




    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GameOverScreen()
    {
        //Showing  restart button
        restartButton.gameObject.SetActive(true); 
        
    }

    public void RestartGame()
    {
        //Using current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

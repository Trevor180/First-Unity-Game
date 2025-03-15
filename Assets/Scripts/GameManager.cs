using UnityEngine;
using UnityEngine.SceneManagement; //Managing Scene
using UnityEngine.UI; //Grabbing buttons and UI
using TMPro; //Can use text mesh pro classes and methods
using System.ComponentModel; 


public class GameManager : MonoBehaviour
{
    //Getting text
    public TextMeshProUGUI scoreText;

    //Player score
    private int score;

    //Making button variable
    public Button restartButton;

    //Getting game over image
    public Image gameOverImage;

    //Getting bomb powerup image
    public Image bombPowerup;

    //Getting player scripts
    private PlayerController playerControllerScript;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Grabbing player object
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();


        //Restarting game when restart button is clicked
        restartButton.onClick.AddListener(RestartGame);

        //Arranging score
        score = 0;


    }

    // Update is called once per frame
    void Update()
    {
        //Adding score
        AddingScore(10);
    }


    public void GameOverScreen()
    {
        //Showing  restart button and game over title
        restartButton.gameObject.SetActive(true);
        gameOverImage.gameObject.SetActive(true);
        
    }

    public void RestartGame()
    {
        //Using current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    //Adding 10 points as long as player is moving
    public void AddingScore(int pointsAdded)
    {
        if (playerControllerScript.gameOver == false)
        {
            // Making score go up smoothly
            score += Mathf.RoundToInt(pointsAdded * (Time.deltaTime * 10.0f));



            scoreText.text = "Score " + score;

            Debug.Log("Score Updating: " + score);

        }

    }


}

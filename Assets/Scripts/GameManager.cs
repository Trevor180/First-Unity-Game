using UnityEngine;
using UnityEngine.SceneManagement; //Managing Scene
using UnityEngine.UI; //Grabbing buttons and UI
using TMPro; //Can use text mesh pro classes and methods
using System.ComponentModel;
using System.Collections;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{
    //Getting text
    public TextMeshProUGUI scoreText;

    //Player score
    private int score;

    //Making button variables
    public Button restartButton;
    public Button tutorialButton;
    public Button backButton;
    public GameObject tutorialScreen;

    //Getting game over image
    public Image gameOverImage;

    //Getting bomb powerup image
    public Image bombPowerup;

    //Getting player script
    private PlayerController playerControllerScript;

    //Getting Spawn Manager script
    private SpawnManager spawnManagerScript;

    //Movement speed of objects 3.5
    private float speed = 2.5f;
    private bool isSpeedingUp = false;
    private float speedIncrease = 0.5f;
    private float speedCap = 15.0f;

    //Making speed getter
    public float GetSpeed()
    {
        return speed;
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //Grabbing player object
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        //Grabbing spawn manager object
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();



        //Restarting game when restart button is clicked
        restartButton.onClick.AddListener(RestartGame);

        //Showing tutorial page
        tutorialButton.onClick.AddListener(OpenTutorialPage);

        //Going back to homepage
         backButton.onClick.AddListener(BackButton);

        //Arranging score
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //Adding score
        AddingScore(10);


        //Speeding up over time
        if(isSpeedingUp == false && playerControllerScript.gameOver == false)
        {
            //Speeding game up over time
            StartCoroutine(SpeedUp());

        }
        

        Debug.Log("Speed has increased to: " + speed);

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


    //Showing tutorial page
    public void OpenTutorialPage()
    {

        //Showing back button
        tutorialScreen.gameObject.SetActive(true);

        //Turning off title screen from player script
        playerControllerScript.titleScreen.gameObject.SetActive(false);
        

    }

    //Going back to main menu
    public void BackButton()
    {

        //Showing back button
        tutorialScreen.gameObject.SetActive(false);

        //Turning off title screen from player script
        playerControllerScript.titleScreen.gameObject.SetActive(true);


    }


    //Adding 10 points as long as player is moving
    public void AddingScore(int pointsAdded)
    {
        if (playerControllerScript.gameOver == false)
        {
            // Making score go up smoothly
            score += Mathf.RoundToInt(pointsAdded * (Time.deltaTime * 10.0f));



            scoreText.text = "Score " + score;
        }

    }

    IEnumerator SpeedUp()
    {
        isSpeedingUp = true;
        yield return new WaitForSeconds(20);

        if (speed < speedCap)
        {
            speed += speedIncrease;

            //subtracting to enemy spawn time
            //spawnManagerScript.SubtractEnemySpawnTime(0.1f);

            isSpeedingUp = false;

        }
        else
        {
            //Capping speed
            speed = speedCap;
            //spawnManagerScript.SetEnemySpawnTime(0.01f);
            isSpeedingUp = false;
        }
           
       
        

    }


}

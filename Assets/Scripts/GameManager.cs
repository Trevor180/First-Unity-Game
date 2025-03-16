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

    //Making button variable
    public Button restartButton;

    //Getting game over image
    public Image gameOverImage;

    //Getting bomb powerup image
    public Image bombPowerup;

    //Getting player scripts
    private PlayerController playerControllerScript;

    //Getting player scripts
    private SpawnManager spawnManagerScript;

    //Movement speed of objects 2.5
    private float speed = 2.5f;
    private bool isSpeedingUp = false;
    private float speedIncrease = 0.5f;
    private float speedCap = 6.5f;

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
        yield return new WaitForSeconds(2);

        if (speed < speedCap)
        {
            speed += speedIncrease;
            isSpeedingUp = false;

        }
        else
        {
            //Capping speed
            speed = speedCap;
            isSpeedingUp = false;
        }
           
       
        

    }


}

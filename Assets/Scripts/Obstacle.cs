using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float outOfBoundsLeftX = -2.51f;
    private float outOfBoundsRightX = 2.75f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       



    }

    // Update is called once per frame
    void Update()
    {
        //Keeping Obstacle in bounds
        KeepObstacleInBounds();

    }


    void KeepObstacleInBounds()
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

        //Keeing obstacle level to floor
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

    }
}

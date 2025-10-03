using System;
using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class WallOnCollissionDetection : MonoBehaviour
{
    [SerializeField]
    Material Walls;

    [SerializeField]
    Material Wall_Collision;

    [SerializeField]
    GameObject GoalReached;

    [SerializeField]
    GameObject PlayerController;

    [SerializeField]
    TextMeshProUGUI gameTime;

     //boolean storing the data for IF a wall has been touched
    bool touchedWall = false;

    //boolean storing play state & float storing playtime
    bool playing = true;
    float playTime = 0.0f;

    //time the walls stay colored after collision detect
    public float touchedTime = 1f;

    //speed of which walls with the tag="Rotating Obstacle" spin around
    [SerializeField]
    float wallRotationSpeed = 100f;

    //----------------------------------------------------------
    void OnCollisionEnter(Collision wallCollision)
    {
        if (wallCollision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "LevelWalls")
            {
                Debug.Log(wallCollision.gameObject.name);
                gameObject.GetComponent<MeshRenderer>().material = Wall_Collision;
                touchedWall = true;
            }
        }
    }

    void OnTriggerEnter(Collider goalTrigger)
    {
        if (gameObject.tag == "Goal")
        {
            //Debug.Log("Hola");
            //sets the finished screen active. 
            GoalReached.SetActive(true);

            //disables player inputs and character.
            //code//PlayerController.SetActive(false);

            //does the same as above but better
            goalTrigger.GetComponent<PlayerMovement>().enabled = false;
            //sets the boolean for playing to false in order to stop the countdown.
            playing = false;
            //sends the data of playtime into a textSpring
            gameTime.text = playTime.ToString();
        }
    }
    private void Update()
    {
        //walls color change for a time on collision
        if (touchedWall == true)
        {
            touchedTime = touchedTime - Time.deltaTime;
            if (touchedTime < 0.0f)
            {
                gameObject.GetComponent<MeshRenderer>().material = Walls;
                touchedWall = false;
                touchedTime = 1f;
            }
        }

        //rotating obstacle transform on tags
        if (gameObject.tag == "RotatingObstacle")
        {
            //Debug.Log("helloworld");
            transform.Rotate(0.0f, wallRotationSpeed * Time.deltaTime, 0.0f);
        }

        //playtime adder logic and UI implementation.
        if (playing == true)
        {
            playTime = playTime + Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousMoving : MonoBehaviour
{
    public float movementSpeed;
    public float enemyMovementSpeed;
    public static float powerUpMovementSpeed;
    public static float sideCarMovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 2.5f; // Speed of player
        enemyMovementSpeed = -1f; // Speed of enemy
        powerUpMovementSpeed = -1f; // Speed of scrap metal
        sideCarMovementSpeed = -1f; // Speed of side cars
    }

    // Update is called once per frame
    void Update()
    {
        // Check tags
        // if tag is "player", move forward, if tag is "enemy" move backwards. camera, forwards
        if (gameObject.tag == "Player")
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (gameObject.tag == "MainCamera")
        {
            Camera.main.transform.position += Camera.main.transform.up * Time.deltaTime * movementSpeed;
        }
        else if (gameObject.tag == "Enemy")
        {
            transform.position += transform.forward * Time.deltaTime * enemyMovementSpeed;
        }
        else if (gameObject.tag == "ScrapMetal")
        {
            transform.position += transform.forward * Time.deltaTime * powerUpMovementSpeed;
        }
        else if (gameObject.tag == "SideCars")
        {
            transform.position += transform.forward * Time.deltaTime * sideCarMovementSpeed;
        }
    }
}

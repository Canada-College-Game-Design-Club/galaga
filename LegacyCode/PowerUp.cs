using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    // I will comment this better tomorrow.


    // Fields
    public GameObject scrapMetal;
    public Vector3 player;
    public bool isActivated;

    public float movementSpeed;
    public float contMovementSpeed;

    void Start()
    {
        // Setting the fields
        scrapMetal = GameObject.Find("ScrapMetal");
        isActivated = false;

        movementSpeed = 7; // Speed of moving with player left and right
        contMovementSpeed = 2.5f; // Speed of moving with player forward (should be same as player speed)
    }

    // Checks if there is a collision
    void OnCollisionEnter(Collision collision)
    {
        // Collider powerUp = GameObject.Find("ScrapMetal").GetComponent<BoxCollider>();

        // Checks if the scrap metal is touching the player, if yes then activate the power up.
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Activate Powerup");
            ActivateShield();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if (isActivated)
        {
            transform.position += transform.forward * Time.deltaTime * contMovementSpeed;

        }
    }

    // Method for activating the power up shield.
    void ActivateShield()
    {
        Debug.Log("Power up starting");

        player = GameObject.Find("Player").transform.position;

        // Moves the scrap metal shield in front of the player (maybe an animation)
        scrapMetal.transform.position = new Vector3(player.x, player.y, player.z + 2); // Set the location of the scrapmetal to the location of the player (for now)

        isActivated = true;
        BoxCollider powerUp = GameObject.Find("ScrapMetal").GetComponent<BoxCollider>() as BoxCollider;
        powerUp.isTrigger = true;

        ContinousMoving.powerUpMovementSpeed = 0;

        Debug.Log("Powerup activated");
    }

    // This is just keeping the scrap metal shield moving with the player.
    void FixedUpdate()
    {
        if (isActivated)
        {
            if ((Input.GetKey("a") || (Input.GetKey(KeyCode.LeftArrow))) && (!Input.GetKey("d") || (Input.GetKey(KeyCode.RightArrow)))) //left
            {
                transform.position -= transform.right * Time.deltaTime * movementSpeed;//+= going 
            }
            else if ((Input.GetKey("d") || (Input.GetKey(KeyCode.RightArrow))) && (!Input.GetKey("a") || (Input.GetKey(KeyCode.LeftArrow)))) //right
            {
                transform.position += transform.right * Time.deltaTime * movementSpeed; //-= going right
            }
        }
    }
}

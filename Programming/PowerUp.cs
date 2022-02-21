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
    public Collider collider;

    private float movementSpeed;

    void Start()
    {
        // Setting the fields
        scrapMetal = GameObject.Find("ScrapMetal");
        player = GameObject.Find("Player").transform.position;
        isActivated = false;

        collider = GetComponent<Collider>();
        collider.isTrigger = false;

        Debug.Log(collider.isTrigger);

        movementSpeed = 5;
    }

    // Checks if there is a collision
    void OnCollisionEnter(Collision collision)
    {
        Collider powerUp = GameObject.Find("ScrapMetal").GetComponent<BoxCollider>();

        // Checks if the scrap metal is touching the player, if yes then activate the power up.
        if (powerUp.transform.CompareTag("ScrapMetal"))
        {
            Debug.Log("Activate Powerup");
            ActivateShield();
        }
    }

    // Method for activating the power up shield.
    void ActivateShield()
    {
        Debug.Log("Power up starting");

        // Moves the scrap metal shield in front of the player (maybe an animation)
        scrapMetal.transform.position = new Vector3(player.x - 1.5f, player.y, player.z + 2.3f); // Set the location of the scrapmetal to the location of the player (for now)
        isActivated = true;

        // Makes the bullets go through the shield
        collider.isTrigger = true;

        Debug.Log("Trigger is " + collider.isTrigger);

        Debug.Log("Power up done");
    }

    // This is just keeping the scrap metal shield moving with the player.
    void FixedUpdate()
    {
        if (isActivated)
        {
            if ((Input.GetKey("a") || (Input.GetKey(KeyCode.LeftArrow))) && (!Input.GetKey("d") || (Input.GetKey(KeyCode.RightArrow)))) //left
            {
                transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;//+= going 
            }
            else if ((Input.GetKey("d") || (Input.GetKey(KeyCode.RightArrow))) && (!Input.GetKey("a") || (Input.GetKey(KeyCode.LeftArrow)))) //right
            {
                transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed; //-= going right
            }
        }
    }
}

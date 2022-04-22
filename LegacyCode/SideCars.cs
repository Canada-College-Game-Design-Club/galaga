using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCars : MonoBehaviour
{

    public GameObject sideCars;
    public Vector3 player;
    public float contMovementSpeed;
    public bool sideCarsActivated;
    public float movementSpeed; // Speed of player left/right

    private GameObject sideCar2;


    // Start is called before the first frame update
    void Start()
    {
        sideCars = GameObject.Find("SideCars");
        contMovementSpeed = 3.5f;
        sideCarsActivated = false;
        movementSpeed = 7;
    }

    void OnCollisionEnter(Collision collision)
    {

        // Checks if the side car is touching the player, if yes then activate the power up.
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Activating Side Cars");
            ActivateSideCars();
        }
    }

    void ActivateSideCars()
    {
        // Set location to player with changed x axis to move left
        // Duplicate (Instatiate)
        // Set new side cars location to player with changed x axis to move right

        Debug.Log("Activate Side Cars");

        sideCarsActivated = true;

        player = GameObject.Find("Player").transform.position;

        ContinousMoving.sideCarMovementSpeed = 0;

        transform.position = new Vector3(player.x + 2, player.y, player.z);

        sideCar2 = Instantiate(sideCars, new Vector3(player.x - 2, player.y, player.z), sideCars.transform.rotation);

        Debug.Log("Activated.");
    }

    // Update is called once per frame
    void Update()
    {
        if (sideCarsActivated)
        {
            transform.position += transform.forward * Time.deltaTime * contMovementSpeed;
            sideCar2.transform.position += transform.forward * Time.deltaTime * contMovementSpeed;
        }
    }

    // This is just keeping the scrap metal shield moving with the player.
    void FixedUpdate()
    {
        if (sideCarsActivated)
        {
            if ((Input.GetKey("a") || (Input.GetKey(KeyCode.LeftArrow))) && (!Input.GetKey("d") || (Input.GetKey(KeyCode.RightArrow)))) //left
            {
                transform.position -= transform.right * Time.deltaTime * movementSpeed;//+= going
                sideCar2.transform.position -= transform.right * Time.deltaTime * movementSpeed;//+= going 
            }
            else if ((Input.GetKey("d") || (Input.GetKey(KeyCode.RightArrow))) && (!Input.GetKey("a") || (Input.GetKey(KeyCode.LeftArrow)))) //right
            {
                transform.position += transform.right * Time.deltaTime * movementSpeed; //-= going right
                sideCar2.transform.position += transform.right * Time.deltaTime * movementSpeed;//+= going 
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCars : MonoBehaviour
{

    public GameObject sideCars; //gets the side cars object from the hierarchy 
    public Vector3 player; //gets the player for movement
    public float contMovementSpeed;// for continous movement script
    public bool sideCarsActivated; // sets true or false
    public float movementSpeed; // Speed of player left/right

    private GameObject sideCar2;//this will be the 2nd car that is created during game
    public static bool sideCarGun;//made static so that SCShootingBullet can access it, makes sideCarGun True or false.

    // Start is called before the first frame update
    void Start()
    {
        sideCars = GameObject.Find("SideCars");
        contMovementSpeed = 3.5f;
        sideCarsActivated = false;
        movementSpeed = 7;
        sideCarGun = false;
    }

    void OnCollisionEnter(Collision collision)
    {

        // Checks if the side car is touching the player, if yes then activate the power up.
        if (collision.gameObject.tag == "Player")
        {

            Debug.Log("Activating Side Cars");
            activateSideCars();// calls activateSideCars function
            StartCoroutine(sideCarTimer()); // starts SideCars timer after collision

        }



    }

    //timer that destroys side car power up after a certain time
    public IEnumerator sideCarTimer()
    {


        yield return new WaitForSeconds(10f);

        if (gameObject.tag == "SideCars")
        {
            sideCarsActivated = false;
            Destroy(gameObject);
            Destroy(sideCar2);
            Debug.Log("Side Cars OFF");
        }

    }


        void activateSideCars()
    {
        // after function is called, it checks to see if both sideCarsActivated and sideCarGun is set to false.
        if (!sideCarsActivated && !sideCarGun)
        {
            //if both are false, do stuff

            Debug.Log("Activate Side Cars");

            sideCarsActivated = true;

            player = GameObject.Find("Player").transform.position; //gets the player object

            //  ContinousMoving.sideCarMovementSpeed = 0;

            transform.position = new Vector3(player.x + 2, player.y, player.z); // sets sidecar next to player

            // creates a second side car and places it on the other side of player position.
            sideCar2 = Instantiate(sideCars, new Vector3(player.x - 2, player.y, player.z), sideCars.transform.rotation);


            Debug.Log("Activated.");
        }
       
    }

    // Update is called once per frame
     void Update()
     {

     if (sideCarsActivated) //checks if sideCarsActivated is true throughout the whole run time.
         {
             sideCarGun = true; //sets the sideCarGun True, will be checked by SCShootingBullet.cs
        }

    }

    // This is just keeping the side cars moving with the player.
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

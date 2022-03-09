using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{

    public GameObject scrapMetal;
    public Vector3 player;
    public bool isActivated;


    public float movementSpeed;
    public float contMovementSpeed;

   //public static float currentTime;
   // public static float maxTime = 10f;
   // public PowerUpBar powerBar;


    void Start()
    {
        // Setting the starting fields
        scrapMetal = GameObject.Find("ScrapMetal");
        isActivated = false;

        movementSpeed = 7; // Speed of moving with player left and right
        contMovementSpeed = 2.5f; // Speed of moving with player forward (should be same as player speed)

       // currentTime = maxTime;
       // powerBar.SetMaxTime(maxTime);

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//checks to see if the collision is with the main Player
        {
            Debug.Log("Activate Powerup");
            ActivateShield();
          //  maxTime = 10f;
         //   currentTime = maxTime;
          //  powerBar.SetMaxTime(currentTime);
            //InvokeRepeating("Subtract", 1f, 1f);
            StartCoroutine(powerUpCoolDown());

        }
    }

    //timer that destroys PowerUp after a set time.
    public IEnumerator powerUpCoolDown()
    {

        yield return new WaitForSeconds(10f);

        if (gameObject.tag == "ScrapMetal")
        {

            isActivated = false;
            Destroy(gameObject);
        }

        Debug.Log("Scrap Metal OFF");
    }


  //  void Subtract()
    //{
    //    currentTime -= 1f;
   //    powerBar.SetTime(currentTime);
//
   // }






    void ActivateShield()
    {
        Debug.Log("Power up starting");

        player = GameObject.Find("Player").transform.position; //finds player and its positions

        scrapMetal.transform.position = new Vector3(player.x, player.y, player.z + 5); // Set the location of the scrapmetal to the location of the player (for now)

        isActivated = true;

        BoxCollider powerUp = GameObject.Find("ScrapMetal").GetComponent<BoxCollider>() as BoxCollider;
        powerUp.isTrigger = true;



        Debug.Log("Powerup activated");
    }






    void FixedUpdate()
    {
        if (isActivated)//checks to see if powerup isActivated = true, if true it proceeds to take the inputs so it can move along
                        //with the main player
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

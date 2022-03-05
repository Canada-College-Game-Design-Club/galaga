using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{

   

    // Field for starting health.
    public static int health;

    // Field for whether the player is dead (health is 0 or below) This will be important in the future.
    public bool isDead;
    public GameObject player;

    public static int currentHealth;
    public int maxHealth = 100;
    public HealthBar healthBar;


    public Text test;
    public bool flag = false;

    // Field for changing material depending on player health 
    public Material[] material;
    Renderer rend;



    // Start is called before the first frame update
    void Start()
    {
     
        // start
        // geting material components to change color of player when lower health
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        //end



        // Setting the starting health to 100
        health = 100;

        // Setting isDead to false, because the player starts out alive.
        isDead = false;

        // Printing out the starting health, which should always be 100.
        Debug.Log("Starting health: " + health);


        test.text = " ";
        flag = false;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);


    }


   

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            // The player is now dead because the health is equal to or below 0.
            isDead = true;
            test.text = "";
            // Printing out that the player is dead. (Will be replaced with a game over like screen)
            Debug.Log("The player is dead.");
            death();
        }
        // Checks if key pressed is space, if it is then run the code inside curly braces.
        if (Input.GetMouseButtonDown(1))
        {
            // Checks if health is equal to or below 0.
            if (health > 0)
            {
                //else // This is run because the players health is above 0.
                //{
                // Decrease health by 5.
                health -= 5;
                flag = true;
                TakeDamage(5);


                StartCoroutine(oneSecond());
                // Print the new health.
                Debug.Log("Current health: " + health);

                // Call this method to udpate the health bar that is on the screen (UI). I do not have the health bar thing (UI/UX), and Angel is making it so we will run this with the health bar.
                // UpdateHealthBar();
            } //}

        }

    
        //if health is lower or equal to 25 Material changes to set color
        if (health <= 25)
        {
            rend.sharedMaterial = material[1];
        }
        //if health is greater than 25 and lower or equal to 99 Material changes to set color
        else if (health > 25 && health <=74)
        {
            rend.sharedMaterial = material[2];
        }
        //if health is higher or equal to 100 Material changes to set color
        else if (health >= 75)
        {
            rend.sharedMaterial = material[0];
        }

        
    }


    public IEnumerator oneSecond()
    {
        flag = false;
        yield return new WaitForSeconds(.25f);
        DecreaseText();
    }


    void DecreaseText()
    {
        flag = false;
        if (!flag)
        {
            test.text = "";
        }

    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (flag)
        {
            test.text = "- 5";
        }
    }




    //death is called from health <= 0... player object is destroyed
    void death()
    {
        if (gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    // Plan:

    /*
     * 1. Make health field and when SOMETHING happens, lower health by 5. (For now, when space is pressed)
     * 2. Put the "check" in update function, and create UpdateHealthBar() method that does something visual on the screen.
     * 3. Initialize in Start()
     * 4. Account for deadness.
     * 
     */

    // Constraints:

    /* 
     * 1. Health will not be a decimal; it will remain a whole number.
     * 2. Health will have range of 1-100.
     * 
     */

    // Field for starting health.
    public int health;

    // Field for whether the player is dead (health is 0 or below) This will be important in the future.
    public bool isDead;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Setting the starting health to 100
        health = 100;

        // Setting isDead to false, because the player starts out alive.
        isDead = false;

        // Printing out the starting health, which should always be 100.
        Debug.Log("Starting health: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if key pressed is space, if it is then run the code inside curly braces.
        if (Input.GetMouseButtonDown(1))
        {
            // Checks if health is equal to or below 0.
            if (health <= 0)
            {
                // The player is now dead because the health is equal to or below 0.
                isDead = true;
                
                // Printing out that the player is dead. (Will be replaced with a game over like screen)
                Debug.Log("The player is dead.");
                death();
            }
            else // This is run because the players health is above 0.
            {
                // Decrease health by 5.
                health -= 5;

                // Print the new health.
                Debug.Log("Current health: " + health);

                // Call this method to udpate the health bar that is on the screen (UI). I do not have the health bar thing (UI/UX), and Angel is making it so we will run this with the health bar.
                // UpdateHealthBar();
            }
        }
    }
    void death()
    {
        if (gameObject.tag == "Player")
        { 
            Destroy(gameObject);
        }
    }

}
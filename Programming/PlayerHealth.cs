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
     * 
     */

    // Constraints:

    /* 
     * 1. Health will not be a decimal; it will remain a whole number.
     * 2. Health will have range of 1-100.
     * 
     */

    // Field for starting health. It is public in case another aspect of the game needs to access it.
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        // Setting the starting health to 100
        health = 100;

        // Printing out the starting health, which should always be 100.
        Debug.Log("Starting health: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if key pressed is space, if it is then run the code inside curly braces.
        if (Input.GetKeyDown(KeyCode.Space))
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

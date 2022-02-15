/*

NOTE THIS IS NOT A GAME FILE!

*/





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{

    // These are called fields and are defined at the top of the program to set values at the start.
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game has started.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed.");
        }
    }

    // -- Notes --

    /*
     * Debug.Log prints out something to the console.
     * Input.GetKeyDown(KeyCode.Space) checks what key is pressed, specifically the space key.
     * float is an integer but can use decimals. Make sure to add an "f" after each declaration.
     * bool (Boolean) = true or false
     * 
     */


}

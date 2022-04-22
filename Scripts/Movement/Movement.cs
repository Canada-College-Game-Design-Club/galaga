using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Fields
    public float movementSpeed;

    // Use this for initialization and is only run once, at the beginning.
    void Start()
    {
        movementSpeed = 7; // This can be changed depending on how fast you want the player to move. (Left and right)

    }

    // FixedUpdate runs 50 times a second. This is faster and more effecient for movement.
    void FixedUpdate()
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
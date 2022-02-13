using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{

    public float movementSpeed;

    // Use this for initialization
    void Start()
    {
        //no start variables
    }

    //Update is called once per frame
    void FixedUpdate() // (fixed) go every 50 times a second. faster
    {


        if ((Input.GetKey("a") || (Input.GetKey(KeyCode.LeftArrow)) )   && (!Input.GetKey("d") || (Input.GetKey(KeyCode.RightArrow))  )) //left
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;//+= going 
        }
        else if ((Input.GetKey("d")||(Input.GetKey(KeyCode.RightArrow))) && (!Input.GetKey("a")||(Input.GetKey(KeyCode.LeftArrow))   )) //right
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed; //-= going right
        }
    }
}

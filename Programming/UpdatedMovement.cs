using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = .03f;//speed, need f for float
    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");//xdirection
        //float yDirection = Input.GetAxis("Vertical");//ydirection
        //Vector3 moveDirection = new Vector3(xDirection, 0.0f,yDierection);
        Vector3 moveDirection = new Vector3(xDirection, 0.0f);
        transform.position += moveDirection * speed;
    }
}

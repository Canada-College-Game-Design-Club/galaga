using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousMoving : MonoBehaviour
{
    public float movementSpeed; // Speed.

    void Start()
    {
        movementSpeed = 2.5f;
    }

    void Update()
    {
        if (gameObject.tag == "MainCamera")
        {
            Camera.main.transform.position += Camera.main.transform.up * Time.deltaTime * movementSpeed;
        } else if (gameObject.tag == "Player")
        {
            gameObject.transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
    }
}
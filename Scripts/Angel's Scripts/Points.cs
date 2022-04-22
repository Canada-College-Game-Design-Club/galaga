using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    HUDmanager HUDref;
    public float OriginalY;
    AudioSource MyAudioSource; //----------


    // Start is called before the first frame update
    void Start()
    {
        HUDref = FindObjectOfType<HUDmanager>();
        OriginalY = transform.position.y;       // store original position

        //Fetch audio
        MyAudioSource = GetComponent<AudioSource>(); //------------------
    }

    // Update is called once per frame
    void Update()
    {
        if (HUDref.IsGameOver())
        {
            if (transform.position.y != OriginalY)
            {
                transform.position = new Vector3(transform.position.x, OriginalY, transform.position.z);
                Debug.Log("Collectable Reset");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Got Collectable");
        HUDref.AddScore(25);
        transform.position = new Vector3(transform.position.x, transform.position.y + -100.0f, transform.position.z);

        MyAudioSource.Play(); //-------------
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public GameObject rapidFire;
    public GameObject scrapMetal;

    void Start()
    {
        // Generate two random numbers from -21 to 21
        int x1 = Random.Range(-21, 21);
        int x2 = Random.Range(-21, 21);

        float rapidFireX = x1;
        float rapidFireY = rapidFire.transform.position.y;
        float rapidFireZ = rapidFire.transform.position.z;

        rapidFire.transform.position = new Vector3(rapidFireX, rapidFireY, rapidFireZ);

        float scrapMetalX = x2;
        float scrapMetalY = scrapMetal.transform.position.y;
        float scrapMetalZ = scrapMetal.transform.position.z;

        scrapMetal.transform.position = new Vector3(scrapMetalX, scrapMetalY, scrapMetalZ);
    }
}

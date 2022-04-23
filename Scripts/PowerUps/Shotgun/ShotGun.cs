using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public int pelletCount;//amount of pellets fired
    public float spreadAngle; //angle spread
    public GameObject pellet;//bullet prefab
    public Transform BarrelExit;
    public float pelletFireVel = 1;
    List<Quaternion> pellets;

    public static bool ShotGunPowerUp;
    public GameObject shotGun;

    void Start()
    {
        //starting instances
        shotGun = GameObject.Find("ShotGun");

        ShotGunPowerUp = false;


    }

    // Update is called once per frame
    void Awake()
    {
        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }

    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Activate ShotGun");
            ActivateSG();
         //   StartCoroutine(rfCoolDown());

        }
    }

    void ActivateSG()
    {
        int i = 0;
        foreach (Quaternion quat in pellets.ToArray())
        {
            
            pellets[i] = Random.rotation;
            GameObject p = Instantiate(pellet, BarrelExit.position, BarrelExit.rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
            p.GetComponent<Rigidbody>().AddForce(p.transform.right * pelletFireVel);
            i++;
        }
    }
}

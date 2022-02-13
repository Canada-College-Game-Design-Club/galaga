using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{

    public Transform SpawnPoint;
    public GameObject Bullet;
    public float speed = 5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        
            ShootBullet();
        
    }



    private void ShootBullet()
    {
        GameObject cB = Instantiate(Bullet, SpawnPoint.position, Bullet.transform.rotation);
        Rigidbody rig = cB.GetComponent<Rigidbody>();

        rig.AddForce(SpawnPoint.forward * speed, ForceMode.Impulse);
    }
}

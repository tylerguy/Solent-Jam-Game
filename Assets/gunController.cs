using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public float bulletSpeed = 100f;
    public float bulletLife = 5f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // fire bullet when left mouse button is pressed
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            Destroy(newBullet, bulletLife);
        }
        
    }
}

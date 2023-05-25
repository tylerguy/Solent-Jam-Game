using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunController : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    public float bulletSpeed = 100f;
    public float bulletLife = 5f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    RaycastHit hit;

    private GameObject bulletDirection;
    void Start()
    {
        bulletDirection = GameObject.Find("bulletDirection");
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // fire bullet when left mouse button is pressed
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            // cast a ray in the direction the camera is facing
            int layerMask = 1 << 12;
            GameObject.Find("Canvas").GetComponent<UIController>().updateBulletsFired();

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, Mathf.Infinity, layerMask))
            {
                // if the ray hits an enemy, destroy the enemy
                Debug.DrawRay(cam.transform.position, cam.transform.eulerAngles, Color.red, 100f);
                Debug.Log("Hit");
                GameObject.Find("Enemy").GetComponent<enemyBehaviour>().takeDamage(10);
                GameObject.Find("Canvas").GetComponent<UIController>().updateEnemiesHit();
                nextFire = Time.time + fireRate;
            }
            else
            {
                Debug.DrawRay(cam.transform.position, cam.transform.eulerAngles, Color.green, 100f);
                Debug.Log("Missed");
                nextFire = Time.time + fireRate;
            }
        }
    }
}

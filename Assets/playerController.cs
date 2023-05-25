using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private GameObject player;
    private Camera cam;
    public float speed = 0.1f;
    public float jumpForce = 100f;
    public float sensitivity = 1f;
    public bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // rotate player when mouse is moved left or right
        player.transform.Rotate(0, Input.GetAxis("Mouse X")*sensitivity, 0);
        // rotate camera when mouse is moved up or down
        cam.transform.Rotate(-Input.GetAxis("Mouse Y")*sensitivity, 0, 0);
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // move player forward when W is pressed
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(0, 0, speed);
        }
        // move player backward when S is pressed
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(0, 0, -speed);
        }
        // move player left when A is pressed
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(-speed, 0, 0);
        }
        // move player right when D is pressed
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(speed, 0, 0);
        }
        // move player up when Space is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                player.GetComponent<Rigidbody>().AddForce(0, jumpForce, 0);
                isGrounded = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // check if player is touching the ground
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }   
    }    
}

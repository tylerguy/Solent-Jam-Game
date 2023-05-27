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
    public RaycastHit hit;
    private GameObject interact;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        interact = GameObject.Find("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        // rotate player when mouse is moved left or right
        player.transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        // rotate camera when mouse is moved up or down
        // limit camera rotation to 90 degrees up or down
        float camRotation = Input.GetAxis("Mouse Y") * sensitivity;
        float currentRotation = cam.transform.localRotation.eulerAngles.x;
        if (currentRotation > 180)
        {
            currentRotation -= 360;
        }
        float newRotation = Mathf.Clamp(currentRotation - camRotation, -90, 90);
        cam.transform.localRotation = Quaternion.Euler(newRotation, 0, 0);

        int layerMask = 1 << 13;

        // cast a ray in the direction the camera is facing
        // if the ray hits an interactable object, get the gameobject hit and call the interact function
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            interact.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.transform.gameObject.GetComponent<interactableHandler>().interact();
            }
        }
        // else
        // {
        //     interact.SetActive(false);
        // }
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

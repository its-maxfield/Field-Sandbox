using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private vars
    [SerializeField]
    private float pSpeed = 1.0f;

    [SerializeField]
    private float rSpeed = 45.0f;

    [SerializeField, Range(0.0f, 2.25f)]
    private float sprintSpeed = 1.25f;

    [SerializeField]
    bool bInvertLookAxis = true;
    
    [SerializeField]
    Camera playerCam;

    [SerializeField]
    float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded = true;

    GameObject playerBase;
    int lookAxis = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(playerBase == null)
        {
            playerBase = this.gameObject;
        }

        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();

        lookAxis = bInvertLookAxis ? -1 : 1;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "JumpFloor")
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "JumpFloor")
            isGrounded = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Prevent multiple jumps in air
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Positional movement
        float horzDis = Input.GetAxis("Horizontal");
        float vertDis = Input.GetAxis("Vertical");

        bool shifted = false;
        if(Input.GetKey(KeyCode.LeftShift))
            shifted = true;

        float sprintVal = shifted ? sprintSpeed : 1.0f;

        Vector3 direction = (transform.forward * vertDis + transform.right * horzDis) * pSpeed * sprintVal * Time.deltaTime;
        Vector3 playerPos = playerBase.transform.position;
        playerPos += direction;
        playerBase.transform.position = playerPos;

        //Rotational movement
        playerBase.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rSpeed);
        
        playerCam.transform.Rotate(new Vector3(lookAxis * Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * rSpeed);
    }
}

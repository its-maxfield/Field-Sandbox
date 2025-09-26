using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float pSpeed = 1.0f;

    [SerializeField]
    private float rSpeed = 45.0f;

    //Private vars
    GameObject playerBase;

    // Start is called before the first frame update
    void Start()
    {
        if(playerBase == null)
        {
            playerBase = this.gameObject;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Positional movement
        float horzDis = Input.GetAxis("Horizontal");
        float vertDis = Input.GetAxis("Vertical");

        Vector3 direction = (transform.forward * vertDis + transform.right * horzDis) * pSpeed;

        Vector3 playerPos = playerBase.transform.position;
        playerPos += direction;
        playerBase.transform.position = playerPos;

        //Rotational movement
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rSpeed);
    }
}

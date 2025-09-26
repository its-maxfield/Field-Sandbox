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

    [SerializeField]
    bool bInvertLookAxis = true;
    
    [SerializeField]
    Camera playerCam;

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

        lookAxis = bInvertLookAxis ? -1 : 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Positional movement
        float horzDis = Input.GetAxis("Horizontal");
        float vertDis = Input.GetAxis("Vertical");

        Vector3 direction = (transform.forward * vertDis + transform.right * horzDis) * pSpeed * Time.deltaTime;

        Vector3 playerPos = playerBase.transform.position;
        playerPos += direction;
        playerBase.transform.position = playerPos;

        //Rotational movement
        playerBase.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rSpeed);
        
        playerCam.transform.Rotate(new Vector3(lookAxis * Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * rSpeed);
    }
}

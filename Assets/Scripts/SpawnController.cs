using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private Transform startSpawn;

    [SerializeField]
    private GameObject playerPrefab;

    private GameObject playerRef;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = Instantiate(playerPrefab, startSpawn.position, Quaternion.identity);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDING");
        if(other.gameObject.layer == 3) 
        {
            playerRef.transform.position = startSpawn.position;
        }
    }
}
